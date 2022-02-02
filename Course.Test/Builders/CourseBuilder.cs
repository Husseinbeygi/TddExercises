using Academy.Domain.CourseAgg;

namespace Academy.Domain.Tests.Unit.Builders
{
    public class CourseBuilder
    {
        public int id = 1;
        public string name = "TDD";
        public bool isOnline = true;
        public double tuition = 600;


        public CourseBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
        public CourseBuilder WithTuition(double tuition)
        {
            this.tuition = tuition;
            return this;
        }


        public Course Build()
        {
            return new Course(id, name, isOnline, tuition);
        }

        public CourseBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }
    }
}
