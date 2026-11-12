namespace EduLens.Domain.Entities;

public class Programme
{
    public int ProgrammeId { get; set; }

    public string ProgrammeName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public Department Department { get; set; } = null!;

    public ICollection<Student> Students { get; set; } = new List<Student>();
}