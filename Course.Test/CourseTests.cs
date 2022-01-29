
using Academy.Domain.Course;
using Academy.Domain.Exceptions;
using Course_Test.CollectionFixtures;
using FluentAssertions;
using System;
using Xunit;

namespace Course_Test
{
    [Collection("ColFix")]
    public class CourseTests : IClassFixture<identifierFixture>
    {
        private readonly Course course;
        private readonly identifierFixture identifierFixture;

        public CourseTests(identifierFixture identifierFixture, CollFixtrues collectionFixture)
        {
            var courseBuilder = new CourseBuilder();
            course = courseBuilder.Build();
            this.identifierFixture=identifierFixture;
        }

        [Fact]
        public void Constractor_ShouldConstractProperly()
        {

            var g = identifierFixture.guid;
            // Arange 
            const int id = 1;
            const string name = "TDD";
            const bool isOnline = true;
            const double tuition = 600;


            course.Id.Should().Be(id);
            course.Name.Should().Be(name);
            course.IsOnline.Should().Be(isOnline);  
            course.Tuition.Should().Be(tuition);
            course.sections.Should().BeEmpty() ;  
        }



        [Fact]
        public void SouldThrowError_When_NameIsNullOrEmpty()
        {

            var g = identifierFixture.guid;

            var courseBuilder = new CourseBuilder(); 
            // Act
            var course = () => courseBuilder.WithName("").Build();

            //Assert
            course.Should().ThrowExactly<CourseNameIsInvalidException>(); 
        }


        [Fact]
        public void ShouldThrowError_When_TuitionIsNegetive()
        {
            var courseBuilder = new CourseBuilder();

            // Act
            var course = () => courseBuilder.WithTuition(-1).Build();

            //Assert
            course.Should().ThrowExactly<CourseTuitionIsNegetiveException>();
        }


        [Fact]
        public void ShouldAddNewSection_WhenNewSectionIsCreated()
        {
            int id = 1; 
            string name = "SectionTest";

            var courseBuilder = new CourseBuilder();
            var course = courseBuilder.Build();
            var sectionToAdd = new Section(id,name);


            course.AddSection(sectionToAdd);


            course.sections.Should().ContainEquivalentOf(sectionToAdd);

        }

    }
}