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
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;

        public CourseService(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _repository.All().ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _repository.Find(c => c.CourseId == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Course course)
        {
            await _repository.AddAsync(course);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            _repository.Update(course);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var course = await GetByIdAsync(id);
            if (course != null)
            {
                _repository.Delete(course);
                await _repository.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Course with ID {id} not found.");
            }
        }
    }
}
