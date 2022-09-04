using FirstDemo.Data;
using FirstDemo.Training.DbContexts;
using FirstDemo.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.UnitOfWorks
{
    public class CourseEnrollementUnitOfWork : UnitOfWork, ICourseEnrollementUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }

        public CourseEnrollementUnitOfWork(ITrainingDbContext dbContext,
            ICourseRepository courseRepository,
            IStudentRepository studentRepository) : base((DbContext)dbContext)
        {
            Courses = courseRepository;
            Students = studentRepository;
        }
    }
}
