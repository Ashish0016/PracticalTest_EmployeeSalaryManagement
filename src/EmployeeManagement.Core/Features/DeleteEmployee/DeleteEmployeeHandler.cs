using EmpMgmt.DataAccess;
using EmpMgmt.DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.Core.Features.DeleteEmployee
{
    public record DeleteEmployeeModel(int employeeId) : IRequest<Unit>;
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeModel, Unit>
    {
        private readonly EmployeeManagementContext _context;
        public DeleteEmployeeHandler(EmployeeManagementContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteEmployeeModel request, CancellationToken cancellationToken)
        {
            Employee? employee = await _context.Employee
                 .FirstOrDefaultAsync(prop => prop.Id == request.employeeId, cancellationToken);

            if (employee == null) return Unit.Value; // TODO: Hande the exception

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
