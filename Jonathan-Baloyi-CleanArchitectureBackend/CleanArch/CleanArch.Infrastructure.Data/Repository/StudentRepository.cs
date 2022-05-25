using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infrastructure.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDBContext _schoolDBContext;

        public StudentRepository(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = _schoolDBContext.Students;
            return await Task.FromResult(students);
        }

        public async Task<Student> AddStudent(Student student)
        {
            // Add a student and then return the student after adding
            _schoolDBContext.Students.Add(student);
            await _schoolDBContext.SaveChangesAsync();
            return await Task.FromResult(student);
        }
    }
}
