using Academy.Application.Dtos;

namespace Academy.Application
{
    public interface ICourseApplication
    {
        int Create(CreateCourse command);
        int Update(EditCourse courseTest);
    }
}