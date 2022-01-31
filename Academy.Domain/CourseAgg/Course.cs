using Academy.Domain.Exceptions;

namespace Academy.Domain.CourseAgg
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsOnline { get; private set; }
        public double Tuition { get; private set; }
        public List<Section> sections { get; private set; }
        public Course(int id, string name, bool isOnline, double tuition)
        {
            GuardForNull(name);
            GuardForNegetive(tuition);

            Id=id;
            Name=name;
            IsOnline=isOnline;
            Tuition=tuition;
            sections=new List<Section>();
        }

        private static void GuardForNull(string Value)
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new CourseNameIsInvalidException();
            }
        }

        private static void GuardForNegetive(double Value)
        {
            if (Value < 0)
            {
                throw new CourseTuitionIsNegetiveException();

            }
        }

        public void AddSection(Section section)
        {
            sections.Add(section);
        }
    }
}