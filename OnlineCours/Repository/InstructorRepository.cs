using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OnlineCours.DTO;
using OnlineCours.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;

namespace OnlineCours.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        Context _context {get; set;}
        public InstructorRepository(Context context) 
        { 
            _context= context;
        }
        public Instructor CreateAsync(Instructor entity)
        {
            _context.Add(entity);

            return entity;
        }

        public async Task<string> Delete(string id)
        {
            Instructor instructor = _context.Instructors.Include(ins => ins.applicationUser).Include(x => x.InstructorSubjectBridge).FirstOrDefault(Instructor => Instructor.applicationUserID == id);

            if (instructor != null)
            {
                instructor.applicationUser.IsDeleted = true;
                await _context.SaveChangesAsync();
                return "DeletedSuccessfully";
            }
            return "Id Not Found";
        }

        public async Task<List<InstructorDTO>> GetAllAsync()
        {
            List<Instructor> instructors = _context.Instructors
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(bridge => bridge.Subject) 
            .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(bridge => bridge.Instructors) 
            .Include(x => x.applicationUser)
            .ToList();


            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in instructors)
            {
                var appointments = instructor.InstructorSubjectBridge.appointments.Select(x=>x.DayOfWeek).ToList();
                var subjects = _context.Subjects
                .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == instructor.applicationUserID)).Select(x=>x.Name)
                .ToList();

                insDTO.Add(new InstructorDTO
                {
                    Name = instructor.applicationUser.Name,
                    status = instructor.status,
                    Appointments = appointments,
                    Subjects = subjects
                });
            }

            return insDTO;
        }


        public async Task<InstructorDTO> GetById(string Id)
        {
            Instructor Instructor = _context.Instructors
                .Include(x => x.InstructorSubjectBridge)
                .ThenInclude(x => new { x.Subject, x.Instructors })
                .Include(x => x.applicationUser)
                .FirstOrDefault(Instructor => Instructor.applicationUserID == Id);

            InstructorDTO insDTO = new InstructorDTO();

            
                var appointments = Instructor.InstructorSubjectBridge.appointments.Select(x => x.DayOfWeek).ToList();
                var subjects = _context.Subjects
                .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == Instructor.applicationUserID)).Select(x => x.Name)
                .ToList();

                insDTO = new InstructorDTO
                {
                    Name = Instructor.applicationUser.Name,
                    status = Instructor.status,
                    Appointments = appointments,
                    Subjects = subjects
                };
            
            return insDTO;
        }
        public async Task<List<InstructorDTO>> Get(Expression<Func<Instructor, bool>> expression)
        {
            List<Instructor> Instructor = _context.Instructors.Where(expression).ToList();
            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in Instructor)
            {
                var appointments = instructor.InstructorSubjectBridge.appointments.Select(x => x.DayOfWeek).ToList();
                var subjects = _context.Subjects
                .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == instructor.applicationUserID)).Select(x => x.Name)
                .ToList();

                insDTO.Add(new InstructorDTO
                {
                    Name = instructor.applicationUser.Name,
                    status = instructor.status,
                    Appointments = appointments,
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
            List<Instructor> instructors = _context.Instructors
        .Include(x => x.InstructorSubjectBridge)
        .ThenInclude(x => x.appointments)
        .Where(x => x.InstructorSubjectBridge.appointments
            .Any(appointment => (int)appointment.DayOfWeek == DayOfWeek)).ToList();


            List<InstructorDTO> insDTO = new List<InstructorDTO>();

            foreach (var instructor in instructors)
            {
                var appointments = instructor.InstructorSubjectBridge.appointments.Select(x => x.DayOfWeek).ToList();
                var subjects = _context.Subjects
                .Where(s => s.InstructorSubjectBridge.Instructors.Any(i => i.applicationUserID == instructor.applicationUserID)).Select(x => x.Name)
                .ToList();

                insDTO.Add(new InstructorDTO
                {
                    Name = instructor.applicationUser.Name,
                    status = instructor.status,
                    Appointments = appointments,
                    Subjects = subjects
                });
            }

            return insDTO;
        }

        public bool Exists(string id)
        {
            var ins = _context.Instructors.Where(x => x.applicationUserID == id);

            if(ins != null)
            {
                return true;
            }
            return false;
        }
    }
}
