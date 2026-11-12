namespace EduLens.Application.DTOs;

public class ProgrammeDto
{
    public int ProgrammeId { get; set; }

    public string ProgrammeName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;
}

public class CreateProgrammeDto
{
    public string ProgrammeName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
}

public class UpdateProgrammeDto
{
    public string ProgrammeName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
}