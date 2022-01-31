using Academy.Application.Dtos;
using Academy.Domain.CourseAgg;
using Academy.Framework;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Academy.Application.Tests.Unit
{
    public class ApplicationTests
    {
        [Fact]
        public void Should_CreateNewCourse()
        {
            var TestCourse = new CreateCourse()
            {
                Id = 14,
                IsOnline = true,
                Name = "TestCourse",
                Tuition = 4900
            };



            var CourseSubstitute = Substitute.For<ICourseRepository>();
            var _courseApplication = new CourseApplication(CourseSubstitute);
            var result = _courseApplication.Create(TestCourse);

            CourseSubstitute.Received(1).Create(Arg.Any<Course>());
        }
        [Fact]
        public void ShouldReturnDuplicatedCode_WhenCourseWasDuplicated()
        {
            var TestCourse = new CreateCourse()
            {
                Id = 14,
                IsOnline = true,
                Name = "TestCourse",
                Tuition = 4900
            };

            var CourseSubstitute = Substitute.For<ICourseRepository>();
            CourseSubstitute.Getby(Arg.Any<string>())
                            .Returns(new Course(TestCourse.Id, TestCourse.Name, TestCourse.IsOnline, TestCourse.Tuition));
            var _courseApplication = new CourseApplication(CourseSubstitute);
            var result = _courseApplication.Create(TestCourse);

            result.Should().Be(OperationResult.Duplicated);
        }


    }
}