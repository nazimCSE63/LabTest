using FirstDemo.Training.BusinessObjects;
using FirstDemo.Training.Exceptions;
using FirstDemo.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseEntity = FirstDemo.Training.Entities.Course;

namespace FirstDemo.Training.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseEnrollementUnitOfWork _courseEnrollementUnitOfWork;

        public CourseService(ICourseEnrollementUnitOfWork courseEnrollementUnitOfWork)
        {
            _courseEnrollementUnitOfWork = courseEnrollementUnitOfWork;
        }

        public void CreateCourse(Course course)
        {
            var courseCount = _courseEnrollementUnitOfWork.Courses.GetCount(x => x.Name == course.Name);

            if (courseCount == 0)
            {
                var entity = new CourseEntity
                {
                    Name = course.Name,
                    Fee = course.Fees
                };

                _courseEnrollementUnitOfWork.Courses.Add(entity);
                _courseEnrollementUnitOfWork.Save();
            }
            else
                throw new DuplicateException("Course with same name already exists");
        }

        public (int total, int totalDisplay, IList<Course> records) GetCourses(int pageIndex,
            int pageSize, string searchText, string orderBy)
        {
            var result = _courseEnrollementUnitOfWork.Courses.GetDynamic(x => x.Name.Contains(searchText),
                orderBy, string.Empty, pageIndex, pageSize, true);

            List<Course> courses = new List<Course>();
            foreach (CourseEntity course in result.data)
            {
                courses.Add(new Course
                {
                    Id = course.Id,
                    Name = course.Name,
                    Fees = course.Fee
                });
            }

            return (result.total, result.totalDisplay, courses);
        }
    }
}
