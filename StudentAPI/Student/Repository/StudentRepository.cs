using Microsoft.EntityFrameworkCore;
using Student.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }       

        public async Task<Model.Student> AddStudentAsync(Model.Student student)
        {
            await _studentContext.AddAsync(student);
            await _studentContext.SaveChangesAsync();

            return student;
        }

        public async Task<Model.Student> GetStudentByIdAsync(int id)
        {
            return await _studentContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Model.Student>> GetStudentListAsync()
        {
            return await _studentContext.Students.ToListAsync();
        }
    }
}
