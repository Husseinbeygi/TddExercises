using Academy.Application.Dtos;
using Academy.Domain.CourseAgg;
using Academy.Framework;

namespace Academy.Application
{
    public class CourseApplication
    {
        private readonly ICourseRepository courseRepository;

        public CourseApplication(ICourseRepository courseRepository)
        {
            this.courseRepository=courseRepository;
        }


        public int Create(CreateCourse command)
        {
            if (courseRepository.Getby(command.Name) != null)
            {
                return OperationResult.Duplicated;
            }


            var course = new Course(command.Id, command.Name, command.IsOnline, command.Tuition);

            courseRepository.Create(course);

            return OperationResult.Succedded;
        }
    }
}