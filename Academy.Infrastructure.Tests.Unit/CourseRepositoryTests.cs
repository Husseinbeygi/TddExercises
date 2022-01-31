using Academy.Domain.Tests.Unit.Builders;
using Academy.Infrastructre.Repository;
using FluentAssertions;
using System;
using Xunit;

namespace Academy.Infrastructure.Tests.Unit
{
    public class CourseRepositoryTests
    {
        private readonly CourseRepository _courseRepository;    
        private readonly CourseBuilder _courseBuilder;
        public CourseRepositoryTests()
        {
            _courseRepository = new CourseRepository();
            _courseBuilder = new CourseBuilder();

        }

        [Fact]
        public void ShouldCreateCourse_WhenNewCourseAdded()
        {
            var course = _courseBuilder.Build();

            _courseRepository.Create(course);

            _courseRepository.Course.Should().Contain(course);
        }

        [Fact]
        public void Should_ReturnListOFCorses()
        {
            var courses = _courseRepository.GetAll();

            courses.Should().HaveCountGreaterThanOrEqualTo(0);
            
        }

        [Fact]
        public void Should_ReturnCouerseById()
        {
            int id = 3;
            var expected = _courseBuilder.WithId(id).Build();
            _courseRepository.Create(expected);


            var actual = _courseRepository.Getby(id);

            actual.Should().BeEquivalentTo(expected);   
            
        }

        [Fact]
        public void ShouldReturnDefault_WhenCourseIdNotExist()
        {
            var expected = new CourseBuilder()
                .WithId(0)
                .WithName("Default")
                .WithTuition(0.0)
                .Build();

            var actual = _courseRepository.Getby(50);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void Should_RemoveCourseById()
        {
            int id = 3;
            var expected = _courseBuilder.WithId(id).Build();
            _courseRepository.Create(expected);

            _courseRepository.Remove(id);

            var actual = _courseRepository.GetAll();

            actual.Should().NotContain(expected);

        }


        [Fact]
        public void Should_ReturnCouerseByName()
        {
            string name = "CTest";
            var expected = _courseBuilder.WithName(name).Build();
            _courseRepository.Create(expected);
                

            var actual = _courseRepository.Getby(name);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public void ShouldReturnDefault_WhenCourseNameNotExist()
        {

            var expected = new CourseBuilder()
                .WithId(0)
                .WithName("Default")
                .WithTuition(0.0)
                .Build();

            var actual = _courseRepository.Getby("EmptyName");

            actual.Should().BeEquivalentTo(expected);

        }
    }
}