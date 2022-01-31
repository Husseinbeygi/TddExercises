namespace Academy.Application.Dtos
{
    public class CreateCourse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsOnline { get; set; }
        public double Tuition { get; set; }

    }
}