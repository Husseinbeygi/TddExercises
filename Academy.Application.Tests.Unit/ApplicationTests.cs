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
        private readonly ICourseRepository _courseSubstitute;
        private readonly ICourseApplication _courseApplication;
        public ApplicationTests()
        {
            _courseSubstitute = Substitute.For<ICourseRepository>();
            _courseApplication = new CourseApplication(_courseSubstitute);

        }


        [Fact]
        public void Should_CreateNewCourse()
        {
            CreateCourse TestCourse = SomeCourseForCreate();

            var result = _courseApplication.Create(TestCourse);


            _courseSubstitute.Received(1).Create(Arg.Any<Course>());
            result.Should().Be(OperationResult.Succedded);
        }


        [Fact]
        public void ShouldReturnDuplicatedCode_WhenCourseWasDuplicated()
        {
            CreateCourse TestCourse = SomeCourseForCreate();

            _courseSubstitute.Getby(Arg.Any<string>())
                            .Returns(new Course(TestCourse.Id, TestCourse.Name, TestCourse.IsOnline, TestCourse.Tuition));

            var result = _courseApplication.Create(TestCourse);

            result.Should().Be(OperationResult.Duplicated);
        }
        private static CreateCourse SomeCourseForCreate()
        {
            return new CreateCourse()
            {
                Id = 14,
                IsOnline = true,
                Name = "TestCourse",
                Tuition = 4900
            };
        }

        [Fact]
        public void Should_UpdateCourse()
        {
            EditCourse courseTest = SomeCourseForEdit();

            int result = _courseApplication.Update(courseTest);

            Received.InOrder(() =>
            {
                _courseSubstitute.Received().Remove(courseTest.Id);
                _courseSubstitute.Received().Create(Arg.Any<Course>());
            });
            result.Should().Be(OperationResult.Succedded);
        }

        private static EditCourse SomeCourseForEdit()
        {
            return new EditCourse()
            {
                Id = 14,
                IsOnline = true,
                Name = "TestCourse",
                Tuition = 4900
            };
        }
    }
}