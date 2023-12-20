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
    public class InstructorRepository :PersonRepository<Instructor> , IInstructorRepository
    {
        Context _context { get; set; }
        public InstructorRepository(Context context) : base(context)
        {
            _context = context;
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
                    foreach(var appointment in brid.Appointments)
                    {
                        AppoinstmentDTO appoinstmentDTO = new AppoinstmentDTO();
                        appoinstmentDTO.DayOfWeek = appointment.DayOfWeek;
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


        //public async Task<InstructorDTO> GetById(string Id)
        //{
        //    Instructor Instructor = _context.Instructors
        //        .Include(x => x.InstructorSubjectBridge)
        //        .ThenInclude(x => new { x.Subject, x.Instructor })
        //        .Include(x => x.applicationUser)
        //        .FirstOrDefault(Instructor => Instructor.applicationUserID == Id);

        //    InstructorDTO insDTO = new InstructorDTO();


        //    var appointments = Instructor.InstructorSubjectBridge.appointments.Select(x => x.DayOfWeek).ToList();
        //    var subjects = _context.Subjects
        //    .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == Instructor.applicationUserID)).Select(x => x.Name)
        //    .ToList();

        //    insDTO = new InstructorDTO
        //    {
        //        Name = Instructor.applicationUser.Name,
        //        status = Instructor.status,
        //        Appointments = appointments,
        //        Subjects = subjects
        //    };

        //    return insDTO;
        //}



        //public async Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression)
        //{
        //    List<Instructor> Instructor = _context.Instructors.Where(expression).ToList();
        //    List<InstructorDTO> insDTO = new List<InstructorDTO>();

        //    foreach (var instructor in Instructor)
        //    {
        //        var appointments = instructor.InstructorSubjectBridge.Appointments.Select(x => x.DayOfWeek).ToList();
        //        var subjects = _context.Subjects
        //        .Where(s => s.InstructorSubjectBridge.Instructor.Any(i => i.applicationUserID == instructor.applicationUserID)).Select(x => x.Name)
        //        .ToList();

        //        insDTO.Add(new InstructorDTO
        //        {
        //            Name = instructor.applicationUser.Name,
        //            status = instructor.status,
        //            Appointments = appointments,
        //            Subjects = subjects
        //        });
        //    }

        //    return insDTO;
        //}

        //public async Task UpdateAsync(Instructor entity)
        //{
        //    _context.Instructors.Update(entity);
        //    await _context.SaveChangesAsync();
        //}

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

        //public async Task<List<InstructorDTO>> GetByDay(int DayOfWeek)
        //{
        //    List<Instructor> instructors = _context.Instructors
        //        .Include(x => x.InstructorSubjectBridge)
        //        .ThenInclude(x => x.Appointments)
        //        .Where(x => x.InstructorSubjectBridge.Appointments
        //            .Any(appointment => (int)appointment.DayOfWeek == DayOfWeek)).ToList();


        //    List<InstructorDTO> insDTO = new List<InstructorDTO>();

        //    foreach (var instructor in instructors)
        //    {
        //        var appointments = instructor.InstructorSubjectBridge.Appointments.Select(x => x.DayOfWeek).ToList();
        //        var subjects = _context.Subjects
        //        .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == instructor.applicationUserID)).Select(x => x.Name)
        //        .ToList();

        //        insDTO.Add(new InstructorDTO
        //        {
        //            Name = instructor.applicationUser.Name,
        //            status = instructor.status,
        //            Appointments = appointments,
        //            Subjects = subjects
        //        });
        //    }

        //    return insDTO;
        //}

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
                            DayOfWeek = instructorSubject.DayOfWeek,
                        };

                        instructorSubjectBridge.Appointments.Add(appointment);
                    }

                    _context.InstructorSubjects.Add(instructorSubjectBridge);

                    await _context.SaveChangesAsync();
                }
            }
            return "InstructorSubject added successfully";
        }
    }
}
