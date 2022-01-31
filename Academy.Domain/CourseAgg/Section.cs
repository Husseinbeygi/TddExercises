namespace Academy.Domain.CourseAgg
{
    public class Section
    {
        public Section(int id, string name)
        {
            Id=id;
            Name=name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}