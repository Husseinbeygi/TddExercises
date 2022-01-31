namespace Academy.Domain.CourseAgg
{
    public interface ICourseRepository
    {
        void Create(Course course);
        List<Course> GetAll();
        Course Getby(int id);
        Course Getby(string name);
        void Remove(int id);
    }
}