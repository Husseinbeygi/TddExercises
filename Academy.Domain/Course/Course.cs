using Academy.Domain.Exceptions;

namespace Academy.Domain.Course
{
    public  class Course
    {
        public int Id;
        public string Name;
        public bool IsOnline;
        public double Tuition;
        public List<Section> sections;
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