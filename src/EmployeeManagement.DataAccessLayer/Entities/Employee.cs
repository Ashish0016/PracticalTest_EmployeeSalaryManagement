namespace EmpMgmt.DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
    }
}
