using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineCours.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using OnlineCours.DTO;

namespace OnlineCours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;

        public Context _context { get; }
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, Context systemEntity)
        {
            _userManager = userManager;
            _config = config;
            _context = systemEntity;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Result>> RegisterAsync(RegisterDTO registerDTO)
        { 
            Result result1 = new Result();

            if (ModelState.IsValid)
            {
                ApplicationUser newUsr = new ApplicationUser();

                newUsr.Name = registerDTO.Name;
                newUsr.UserName = registerDTO.UserName;
                newUsr.Email = registerDTO.Email;
                newUsr.PhoneNumber = registerDTO.Phone;

                IdentityResult result = await _userManager.CreateAsync(newUsr, registerDTO.Password);

                if (result.Succeeded)
                {

                    if (registerDTO.Role == "Student")
                    {
                        Student student = new Student();
                        student.ApplicationUserID = newUsr.Id;
                        if (registerDTO.Role == "Student")
                        {
                            var addToRoleResult = await _userManager.AddToRoleAsync(newUsr, "Student");
                            if (!addToRoleResult.Succeeded)
                            {
                                return BadRequest("Failed to assign the 'Student' role.");
                            }
                        }


                        _context.Students.Add(student);
                    }
                    else if (registerDTO.Role == "Instractur")
                    {
                        Instructor instructor = new Instructor();
                        instructor.applicationUserID = newUsr.Id;

                        var addToRoleResult = await _userManager.AddToRoleAsync(newUsr, "Instractur");
                        if (!addToRoleResult.Succeeded)
                        {
                            return BadRequest("Failed to assign the 'Instractur' role.");
                        }
                        _context.Instructors.Add(instructor);
                    }


                }
                _context.SaveChanges();
                result1.Message = "sucess";
                result1.IsPass = true;
                result1.Data = newUsr.UserName;
                return Ok(result1);
            }
            else
            {
                result1.Message = "the register failed";
                result1.IsPass = false;
                return BadRequest(ModelState);
            }

        }


        [HttpPost("UploadImage")]
        public string UploadImage(IFormFile file)
        {
            string FolderPathe = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

            string FileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            string FilePath = Path.Combine(FolderPathe, file.FileName);


            using FileStream FS = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FS);

            return file.FileName;

        }


        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole(string role)
        {

            var roleExist = await _roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
                return Ok("Role is Created");
            }

            return Ok("Is Already Exist");
        }


        [HttpGet("GetAllRoles")] // Change to HTTP GET to retrieve roles
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList(); // Retrieve all roles and convert to a list
            return Ok(roles);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<Result>> LoginAsync(LoginDTO loginDTO)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser Usr = await _userManager.FindByNameAsync(loginDTO.UserName);
                if (Usr != null && await _userManager.CheckPasswordAsync(Usr, loginDTO.Password))
                {
                    IList<string> roles = await _userManager.GetRolesAsync(Usr);

                    List<Claim> myClaims = new List<Claim>();

                    myClaims.Add(new Claim(ClaimTypes.NameIdentifier, Usr.Id));
                    myClaims.Add(new Claim(ClaimTypes.Name, Usr.UserName));
                    myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


                    foreach (var role in roles)
                    {
                        myClaims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    var authSecritKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecuriytKey"]));

                    SigningCredentials credentials =
                        new SigningCredentials(authSecritKey, SecurityAlgorithms.HmacSha256);



                    JwtSecurityToken jtw = new JwtSecurityToken
                        (
                    issuer: "JWT:ValidIssuer",
                            audience: "JWT:ValidAudience",
                            expires: DateTime.Now.AddHours(1),
                            claims: myClaims,
                            signingCredentials: credentials
                        );

                    return Ok(new Result
                    {
                        IsPass = true,
                        Data = new JwtSecurityTokenHandler().WriteToken(jtw),
                        Expairation = jtw.ValidTo,
                        Message = "sucesss"
                    });

                }
                Result result = new Result();
                result.Message = "failed";
                return BadRequest(result);
            }

            return BadRequest(ModelState);
        }
    }
}

