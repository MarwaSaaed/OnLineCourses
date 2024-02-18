using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OCTW.Server.Repository;
using OnlineCours.DTO;
using OnlineCours.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;

namespace OnlineCours.Repository
{
    public class InstructorRepository : PersonRepository<Instructor>, IInstructorRepository
    {
        private readonly IRequestAppointmentRepository _RequestAppointmentRepository;

        Context _context { get; set; }
        public InstructorRepository(Context context, IRequestAppointmentRepository requestAppointmentRepository) : base(context)
        {
            _context = context;
            _RequestAppointmentRepository = requestAppointmentRepository;
        }

        public async Task<string> Delete(string id)
        {
            Instructor instructor = _context.Instructors.Include(ins => ins.applicationUser)
                .Include(x => x.InstructorSubjectBridge)
                .FirstOrDefault(Instructor => Instructor.applicationUserID == id);

            if (instructor != null)
            {
                instructor.applicationUser.IsDeleted = true;
                await _context.SaveChangesAsync();
                return "Deleted Successfully";
            }
            return "Id Not Found";
        }

        public async Task<List<InstructorDTO>> GetAllAsync()
        {
            List<Instructor> instructors = _context.Instructors
            .Include(x => x.applicationUser)
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(bridge => bridge.Subject)
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(bridge => bridge.Appointments)
            .ToList();


            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in instructors)
            {
                List<AppoinstmentDTO> Appointment = new List<AppoinstmentDTO>();
                var BridgeList = instructor.InstructorSubjectBridge.ToList();

                foreach (var brid in BridgeList)
                {
                    foreach (var appointment in brid.Appointments)
                    {
                        AppoinstmentDTO appoinstmentDTO = new AppoinstmentDTO();
                        appoinstmentDTO.DayOfWeek = appointment.DayOfWeek.ToString();
                        appoinstmentDTO.LectureDate = appointment.LectureDate;
                        Appointment.Add(appoinstmentDTO);

                    }
                }
                var subjects = BridgeList.Select(x => x.Subject.Name).ToList();

                insDTO.Add(new InstructorDTO
                {
                    Id = instructor.applicationUserID,
                    Name = instructor.applicationUser.Name,
                    Email = instructor.applicationUser.Email,
                    Phone = instructor.applicationUser.PhoneNumber,
                    status = instructor.status,
                    Appointments = Appointment,
                    Subjects = subjects
                });
            }

            return insDTO;
        }

        public async Task<InstructorDTO> GetById(string Id)
        {
            Instructor Instructor = _context.Instructors
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(x => x.Subject)
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(x => x.Appointments)
            .Include(x => x.applicationUser)
            .FirstOrDefault(i => i.applicationUserID == Id);


            InstructorDTO insDTO = new InstructorDTO();

            List<AppoinstmentDTO> Appointment = new List<AppoinstmentDTO>();
            var BridgeList = Instructor.InstructorSubjectBridge.ToList();

            foreach (var brid in BridgeList)
            {
                foreach (var appointment in brid.Appointments)
                {
                    AppoinstmentDTO appoinstmentDTO = new AppoinstmentDTO();
                    appoinstmentDTO.DayOfWeek = appointment.DayOfWeek.ToString();
                    appoinstmentDTO.LectureDate = appointment.LectureDate;
                    Appointment.Add(appoinstmentDTO);

                }
            }
            var subjects = BridgeList.Select(x => x.Subject.Name).ToList();

            insDTO.Name = Instructor.applicationUser.Name;
            insDTO.status = Instructor.status;
            insDTO.Appointments = Appointment;
            insDTO.Subjects = subjects;

            return insDTO;
        }

        public async Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression)
        {
            List<Instructor> Instructor = _context.Instructors.Where(expression).ToList();
            List<InstructorDTO> insDTO = new List<InstructorDTO>();


            foreach (var instructor in Instructor)
            {
                List<AppoinstmentDTO> Appointment = new List<AppoinstmentDTO>();
                var BridgeList = instructor.InstructorSubjectBridge.ToList();

                foreach (var brid in BridgeList)
                {
                    foreach (var appointment in brid.Appointments)
                    {
                        AppoinstmentDTO appoinstmentDTO = new AppoinstmentDTO();
                        appoinstmentDTO.DayOfWeek = appointment.DayOfWeek.ToString();
                        appoinstmentDTO.LectureDate = appointment.LectureDate;
                        Appointment.Add(appoinstmentDTO);

                    }
                }
                var subjects = BridgeList.Select(x => x.Subject.Name).ToList();

                insDTO.Add(new InstructorDTO
                {
                    Name = instructor.applicationUser.Name,
                    status = instructor.status,
                    Appointments = Appointment,
                    Subjects = subjects
                });
            }


            return insDTO;
        }

        public async Task UpdateAsync(Instructor entity)
        {
            _context.Instructors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Instructor entity, params string[] properties)
        {
            var localEntity = _context.Instructors.Local.Where(x => EqualityComparer<string>.Default.Equals(x.applicationUserID, entity.applicationUserID)).FirstOrDefault();

            EntityEntry entityEntry;

            if (localEntity is null)
            {
                entityEntry = _context.Instructors.Entry(entity);
            }
            else
            {
                entityEntry =
                    _context.ChangeTracker.Entries<Instructor>()
                    .Where(x => EqualityComparer<string>.Default.Equals(x.Entity.applicationUserID, entity.applicationUserID)).FirstOrDefault();
            }
            IEntityType entityType = _context.Model.FindEntityType(entity.GetType());
            foreach (var property in entityEntry.Properties)
            {
                IForeignKey foreignKey = entityType.FindForeignKeys(property.Metadata)
                 .FirstOrDefault(fk => fk.PrincipalEntityType.ClrType == typeof(ApplicationUser));


                if (foreignKey != null)
                {
                    var applicationUserName = entityType.GetNavigations()
                     .FirstOrDefault(n => n.TargetEntityType.ClrType == typeof(ApplicationUser))?
                     .Name;

                    var applicationUserProperty = entity.GetType().GetProperty(applicationUserName);
                    var applicationUserValue = applicationUserProperty?.GetValue(entity);

                    ApplicationUser referencedUser = _context.Set<ApplicationUser>().Find(entity.applicationUserID);
                    EntityEntry userentityEntry = _context.Set<ApplicationUser>().Entry(referencedUser);

                    foreach (var userproperty in userentityEntry.Properties)
                    {
                        if (properties.Contains(userproperty.Metadata.Name))
                        {
                            userproperty.CurrentValue = applicationUserValue.GetType().GetProperty(userproperty.Metadata.Name).GetValue(applicationUserValue);
                            userproperty.IsModified = true;
                        }
                    }

                }
                else if (properties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }
        }

        public async Task<List<InstructorDTO>> GetByDay(int DayOfWeek)
        {
            var instructors = _context.Instructors
            .Where(instructor => instructor.InstructorSubjectBridge != null &&
                                 instructor.InstructorSubjectBridge.Any(bridge =>
                                    bridge.Appointments.Any(appointment => appointment.DayOfWeek == (Day)DayOfWeek)))
            .ToList();



            List<InstructorDTO> insDTO = instructors.Select(instructor => new InstructorDTO
            {
                Name = instructor.applicationUser.UserName,
                status = instructor.status,
                Appointments = instructor.InstructorSubjectBridge
                .SelectMany(bridge => bridge.Appointments
                    .Where(appointment => (int)appointment.DayOfWeek == DayOfWeek)
                    .Select(appointment => new AppoinstmentDTO
                    {
                        LectureDate = appointment.LectureDate,
                        DayOfWeek = appointment.DayOfWeek.ToString()
                    }))
                .ToList(),
                Subjects = instructor.InstructorSubjectBridge
                .Select(bridge => bridge.Subject?.Name)
                .ToList()
            }).ToList();

            return insDTO;
        }

        public bool Exists(string id)
        {
            var ins = _context.Instructors.Where(x => x.applicationUserID == id);

            if (ins != null)
            {
                return true;
            }
            return false;
        }

        public async Task<string> AddInstructorSubject(InstructorSubjectDTO instructorSubjectDTO)
        {
            Instructor instructor = await _context.Instructors
                             .FirstOrDefaultAsync(ins => ins.applicationUserID == instructorSubjectDTO.InstructorId);

            if (instructor != null)
            {
                Subject subject = await _context.Subjects
                                 .FirstOrDefaultAsync(sub => sub.Id == instructorSubjectDTO.SubjectId);

                if (subject != null)
                {
                    InstructorSubjectBridge instructorSubjectBridge = new InstructorSubjectBridge();
                    instructorSubjectBridge.InstructorID = instructor.applicationUserID;
                    instructorSubjectBridge.SubjectID = subject.Id;

                    instructorSubjectBridge.Appointments = new List<Appointment>();

                    foreach (var instructorSubject in instructorSubjectDTO.AppoinstmentDTOs)
                    {
                        Appointment appointment = new Appointment
                        {
                            LectureDate = instructorSubject.LectureDate,
                            DayOfWeek = (Day)int.Parse(instructorSubject.DayOfWeek),
                        };

                        instructorSubjectBridge.Appointments.Add(appointment);
                    }

                    _context.InstructorSubjects.Add(instructorSubjectBridge);

                    await _context.SaveChangesAsync();
                }
            }
            return "InstructorSubject added successfully";
        }
        public async Task<List<StudentRequestForInstructor>> GetAllRequestToByInstructorId(string InstructorId)
        {
            var Query = _context.RequestAppointments
                .Include(i => i.CustomAppointment)
                .ThenInclude(i => i.InstructorSubjectBridge)
                .ThenInclude(i => i.Instructor);

            var Result = Query.Where(i => i.CustomAppointment.InstructorSubjectBridge.InstructorID == InstructorId);
            Result = Result
                .Include(r => r.Request)
                .ThenInclude(s => s.Student);
            var FinalResult = await Result.Select(r => new StudentRequestForInstructor
            {
                CustomAppointmentId = r.CustomAppointmentID,
                DayOfWeek = r.CustomAppointment.DayOfWeek.ToString(),
                Grade = r.Request.Grade,
                LectureDate = r.CustomAppointment.LectureDate,
                RequestId = r.RequestID,
                StudentName = r.Request.Student.ApplicationUser.Name,
                SubjectName = r.CustomAppointment.InstructorSubjectBridge.Subject.Name
            }).ToListAsync();
            return FinalResult;
        }

        public async Task<List<InstructorDTO>> GetBySubject(int SubjectId)
        {
            var instructors = _context.InstructorSubjects
    .Where(bridge => bridge.SubjectID == SubjectId)
    .Include(x => x.Instructor)
        .ThenInclude(x => x.InstructorSubjectBridge)
            .ThenInclude(x => x.Subject)
    .Include(x => x.Instructor)
        .ThenInclude(x => x.applicationUser)
    .Include(x => x.Instructor)
        .ThenInclude(x => x.InstructorSubjectBridge)
            .ThenInclude(x => x.Appointments)
    .AsEnumerable() // To prevent EF Core query translation issues with complex operations
    .GroupBy(r => r.InstructorID)
    .ToList();

            List<InstructorDTO> insDTO = instructors.Select(group => {
                var firstInstructor = group.First().Instructor;
                return new InstructorDTO
                {
                    Name = firstInstructor.applicationUser.UserName,
                    InstructorID = firstInstructor.applicationUser.Id,
                    status = firstInstructor.status,
                    Appointments = group
                        .SelectMany(g => g.Instructor.InstructorSubjectBridge)
                        .SelectMany(bridge => bridge.Appointments)
                        .Where(appointment => !IsInstructorAppointmentRequestedByStudent(appointment, appointment.InstructorSubjectBridgeID))
                        .Select(appointment => new {
                            appointment.LectureDate,
                            DayOfWeek = appointment.DayOfWeek.ToString()
                        })
                        .Distinct() 
                        .Select(appointment => new AppoinstmentDTO
                        {
                            LectureDate = appointment.LectureDate,
                            DayOfWeek = appointment.DayOfWeek
                        })
                        .ToList()
                };
            }).ToList();

            return insDTO;
        }

        private bool IsInstructorAppointmentRequestedByStudent(Appointment instructorAppointment, int instructorSubjectBridgeId)
        {
            var flag = _context.CustomAppointments
                .Any(ca => ca.InstructorSubjectBridgeID == instructorSubjectBridgeId &&
                           (ca.DayOfWeek == instructorAppointment.DayOfWeek || ca.LectureDate == instructorAppointment.LectureDate));

            Console.WriteLine(flag);
            return flag;
        }

        public async Task<List<InstructorDTO>> GetAllPendingInstructoresAsync()
        {
            List<Instructor> instructors = await _context.Instructors
            .Include(x => x.applicationUser)
             .Where(x => x.status == StatusOfInstructor.Pendding).ToListAsync();


            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in instructors)
            {



                insDTO.Add(new InstructorDTO
                {
                    Id = instructor.applicationUserID,
                    Name = instructor.applicationUser.Name,
                    Email = instructor.applicationUser.Email,
                    Phone = instructor.applicationUser.PhoneNumber,
                    status = instructor.status,

                });
            }

            return insDTO;
        }

        public async Task<List<InstructorDTO>> GetAllAcceptedInstructors()
        {
            List<Instructor> instructors = await _context.Instructors
            .Include(x => x.applicationUser)
             .Where(x => x.status == StatusOfInstructor.Accepted).ToListAsync();


            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in instructors)
            {



                insDTO.Add(new InstructorDTO
                {
                    Id = instructor.applicationUserID,
                    Name = instructor.applicationUser.Name,
                    Email = instructor.applicationUser.Email,
                    Phone = instructor.applicationUser.PhoneNumber,
                    status = instructor.status,

                });
            }

            return insDTO;
        }

        public async Task<InstructorDTO> GetInstructorWithSubject(string id)
        {

            var instructorWithSubjects = await _context.InstructorSubjects
                .Include(i => i.Instructor)
                .ThenInclude(s => s.applicationUser)
                .Include(s => s.Subject)
                .Where(s => s.InstructorID == id)
                .ToListAsync();


            if (instructorWithSubjects == null || instructorWithSubjects.Count == 0)
            {
                return null;
            }


            var instructorDTO = new InstructorDTO
            {
                Id = instructorWithSubjects.FirstOrDefault().InstructorID,
                Name = instructorWithSubjects.FirstOrDefault().Instructor.applicationUser?.Name,
                Email = instructorWithSubjects.FirstOrDefault().Instructor.applicationUser?.Email,
                Phone = instructorWithSubjects.FirstOrDefault().Instructor.applicationUser?.PhoneNumber,
                status = instructorWithSubjects.FirstOrDefault().Instructor.status,
                Subjects = instructorWithSubjects.Select(s => s.Subject?.Name).ToList()
            };

            return instructorDTO;
        }


        public async Task<InstructorSubjectsAndAppointmentDTO> GetInstructorSubjectandAppointment(string id)
        {
            var instructorWithSubjectsAndAppointments = await _context.InstructorSubjects
                .Include(i => i.Instructor)
                    .ThenInclude(s => s.applicationUser)
                .Include(s => s.Subject)
                .Include(s => s.Appointments)
                .Where(s => s.InstructorID == id)
                .ToListAsync();

            if (instructorWithSubjectsAndAppointments == null || instructorWithSubjectsAndAppointments.Count == 0)
            {
                return null;
            }

            var instructorDTO = new InstructorSubjectsAndAppointmentDTO
            {
                Id = instructorWithSubjectsAndAppointments.FirstOrDefault().InstructorID,
                Name = instructorWithSubjectsAndAppointments.FirstOrDefault().Instructor.applicationUser.Name,
                SubjectsAppointments = instructorWithSubjectsAndAppointments.SelectMany(s => s.Appointments)
                    .GroupBy(a => a.InstructorSubjectBridge.Subject.Name)
                    .Select(g => new SubjectAppoinstmentDTO
                    {
                        SubjectsName = g.First().InstructorSubjectBridge.Subject.Name,
                        Appointments = g.Select(a => new AppoinstmentDTO
                        {
                            Id = a.Id,
                            LectureDate = a.LectureDate.ToString(),
                            DayOfWeek = a.DayOfWeek.ToString(),
                        }).ToList()
                    }).ToList()
            };

            return instructorDTO;
        }

    }
}
