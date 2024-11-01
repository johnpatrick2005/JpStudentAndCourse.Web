using JpStudentAndCourse.Contracts;
using JpStudentAndCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpStudentAndCourse.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.All().ToListAsync();
        }
        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(a => a.StudentId == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Student student)
        {
            await _repository.AddAsync(student);
        }
        public async Task UpdateAsync(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            _repository.Update(student);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var student = await GetByIdAsync(id);
            if (student != null)
            {
                _repository.Delete(student);
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }
        }
    }
}

