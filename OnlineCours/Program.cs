
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OCTW.Server.Repository;
using OnlineCours.Models;
using OnlineCours.Repository;

namespace OnlineCours
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<Context>(options =>
                          options.UseSqlServer(builder.Configuration.GetConnectionString("ECO")
                          ));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<Context>();

            //builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
            builder.Services.AddScoped<IRequestAppointmentRepository, RequestAppointmentRepository>();
            builder.Services.AddScoped<IRequestRepository, RequestRepository>();
            builder.Services.AddScoped<IPersonRepository<Instructor>, PersonRepository<Instructor>>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}