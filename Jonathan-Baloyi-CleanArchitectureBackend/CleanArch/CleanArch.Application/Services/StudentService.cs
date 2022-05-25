using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetStudents();
        }

        public async Task<Student> AddStudent(Student student)
        {
            return await _studentRepository.AddStudent(student);
        }
    }
}
