using AutoMapper;
using EmpMgmt.DataAccess;
using EmpMgmt.DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmt.Core.Features.AddOrUpdateEmployeeFeature
{
    public class AddOrUpdateEmployeeModel : IRequest<Unit>
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
    }
    public class AddOrUpdateEmployeeHandler : IRequestHandler<AddOrUpdateEmployeeModel, Unit>
    {
        private readonly EmployeeManagementContext _context;
        private readonly IMapper _mapper;
        public AddOrUpdateEmployeeHandler(EmployeeManagementContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(AddOrUpdateEmployeeModel model, CancellationToken cancellationToken)
        {
            Employee? employee = await _context.Employee
                    .Where(prop => prop.EmployeeCode == model.EmployeeCode)
                    .FirstOrDefaultAsync(cancellationToken);

            if (employee is null)
            {
                employee = _mapper.Map<Employee>(model);
                _context.Employee.Add(employee);
            }
            else
            {
                employee = _mapper.Map(model, employee);
                _context.Employee.Update(employee);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
