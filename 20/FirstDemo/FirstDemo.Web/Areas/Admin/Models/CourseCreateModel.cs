using Autofac;
using FirstDemo.Training.BusinessObjects;
using FirstDemo.Training.Services;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class CourseCreateModel
    {
        private ICourseService _courseService;
        private ILifetimeScope _scope;

        [StringLength(100, ErrorMessage = "Title should be less than 100 chars")]
        public string Title { get; set; }
        [Range(0, 50000, ErrorMessage = "Fees should be between 0 to 50,000")]
        public double Fees { get; set; }

        public CourseCreateModel()
        {

        }

        public CourseCreateModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
        }

        internal void CreateCourse()
        {
            var course = new Course() { Name = Title, Fees = Fees };

            _courseService.CreateCourse(course);
        }
    }
}
