using EmpMgmt.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpMgmt.DataAccess.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.EmployeeCode)
                .IsRequired(true)
                .HasMaxLength(4);

            builder
                .Property(prop => prop.EmployeeName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasIndex(prop => prop.EmployeeCode)
                .IsUnique(true);

            builder
                .Property(prop => prop.DateOfBirth)
                .IsRequired(true)
                .HasMaxLength(8);

            builder
                .Property(prop => prop.Gender)
                .HasDefaultValue(Gender.Male);

            builder
                .Property(prop => prop.Department)
                .HasMaxLength(20);

            builder
                .Property(prop => prop.Designation)
                .HasMaxLength(20);

            builder
                .Property(prop => prop.BasicSalary)
                .HasMaxLength(8);
        }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }
}
