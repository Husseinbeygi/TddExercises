using Academy.Domain.CourseAgg;
using System.Collections.Generic;

namespace Academy.Infrastructre.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> Course = new();


        public CourseRepository()
        {
        }


        public void Create(Course course)
        {
            Course.Add(course);
        }

        public List<Course> GetAll()
        {
            return Course.ToList();
        }

        public Course Getby(int id)
        {
            return Course.FirstOrDefault(c => c.Id == id, new Course(0, "Default", true, 0.0));
        }

        public void Remove(int id)
        {
            var c = Getby(id);
            Course.Remove(c);
        }

        public Course Getby(string name)
        {

            return Course.FirstOrDefault(c => c.Name == name, new Course(0, "Default", true, 0.0));
        }
    }
}