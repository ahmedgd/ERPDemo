using Microsoft.EntityFrameworkCore;
using ERPDemo.Models;
namespace ERPDemo.Models;


public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime DateOfJoining { get; set; }  // مهم جدًا
}
