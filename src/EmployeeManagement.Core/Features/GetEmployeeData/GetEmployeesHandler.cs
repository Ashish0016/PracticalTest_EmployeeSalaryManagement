using EmpMgmt.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.Core.Features.GetEmployeeData
{
    public record GetEmployeesModel(int PageNumber, int PageSize) : IRequest<GetEmployeeResponse>;
    public record GetEmployeeResponse(int TotalRecords, List<GetEmployeeResult> Employees);
    public record GetEmployeeResult(
        int Id,
        int EmployeeCode,
        string EmployeeName,
        DateTime DateOfBirth,
        int Gender,
        string Department,
        string Designation,
        float BasicSalary,
        float DearnessAllowance,
        float ConveyanceAllowance,
        float HouseRentAllowance);
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesModel, GetEmployeeResponse>
    {
        private readonly EmployeeManagementContext _context;
        public GetEmployeesHandler(EmployeeManagementContext context)
        {
            _context = context;
        }

        public async Task<GetEmployeeResponse> Handle(GetEmployeesModel request, CancellationToken cancellationToken)
        {
            List<GetEmployeeResult> result = await _context.Employee
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .Select(prop => new GetEmployeeResult(
                    prop.Id,
                    prop.EmployeeCode,
                    prop.EmployeeName,
                    prop.DateOfBirth,
                    prop.Gender,
                    prop.Department,
                    prop.Designation,
                    prop.BasicSalary,
                    prop.BasicSalary * 0.40f, // DearnessAllowance = BasicSalary * 40%
                    Math.Min(prop.BasicSalary * 0.40f * 0.10f, 250), // ConveyanceAllowance =  DearnessAllowance * 10% or 250 (which ever is lower)
                    Math.Max(prop.BasicSalary * 0.25f, 1500) // HouseRentAllowance = BasicSalary * 25%	or 1500 (which ever is higher)
                ))
                .ToListAsync(cancellationToken);

            int count = await _context.Employee.CountAsync();

            return new GetEmployeeResponse(count, result);
        }
    }
}
