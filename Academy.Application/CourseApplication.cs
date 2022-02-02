using Academy.Application.Dtos;
using Academy.Domain.CourseAgg;
using Academy.Framework;

namespace Academy.Application
{
    public class CourseApplication : ICourseApplication
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

        public int Update(EditCourse courseTest)
        {
            courseRepository.Remove(courseTest.Id);
            courseRepository.Create(new Course(courseTest.Id, courseTest.Name, courseTest.IsOnline, courseTest.Tuition));
            return OperationResult.Succedded;

        }
    }
}