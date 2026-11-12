namespace EduLens.Domain.Entities;

public class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public ICollection<Programme> Programmes { get; set; } = new List<Programme>();

    public ICollection<Course> Courses { get; set; } = new List<Course>();

    public ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
}