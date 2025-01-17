namespace EmpMgmt.DataAccess.Entities
{
    public class Employee
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; } // 0 -> Male and 1 -> Female
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
    }
}
