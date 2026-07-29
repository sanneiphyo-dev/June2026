// See https://aka.ms/new-console-template for more information
using June2026.ConsoleApp4;

Console.WriteLine("Hello, World!");

DapperService dapperService = new DapperService();

//dapperService.Read();
//dapperService.Create();
//dapperService.Update();
dapperService.Delete();


public class StudentDto
{
    public int StudentID { get; set; }

    public string? StudentName { get; set; }

    public string? FatherName { get; set; }

    public string? StudentNo { get; set; }

    public string? Email { get; set; }

    public string? MobileNo { get; set; }

    public bool IsDelete { get; set; }
}