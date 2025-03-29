using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWwbApi.Data;
using MyFirstWwbApi.Exception;
using MyFirstWwbApi.Model;
using MyFirstWwbApi.Model.Entity;

namespace MyFirstWwbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Mycontext _context;
        public EmployeeController(Mycontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployee = _context.Employess.ToList();
            return Ok(allEmployee);
        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                PhoneNumber = addEmployeeDto.PhoneNumber,
                salary = addEmployeeDto.salary,
                IsActive = true
            };

            _context.Employess.Add(employeeEntity);
            _context.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public IActionResult UpdateEmployeesSalary(int Id, UpdateEmployeeSalaryDto updateEmployeeDto)
        {
            var employeeEntity = _context.Employess.Find(Id);
            if (employeeEntity == null)
            {
                throw new NotFoundException($"Employee with Id {Id} not found.");
            }
            employeeEntity.salary = updateEmployeeDto.salary;

            _context.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteEmployees(int Id)
        {
            var employeeEntity = _context.Employess.Find(Id);
            if (employeeEntity == null)
            {
                throw new NotFoundException($"Employee with Id {Id} not found.");
            }

            employeeEntity.IsActive = false;
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("{Id:int}")]
        public IActionResult GetByID(int Id)
        {
            var employeeEntity = _context.Employess.Find(Id);
            if (employeeEntity == null)
            {
                throw new NotFoundException($"Employee with Id {Id} not found.");
            }

            return Ok(employeeEntity);
        }

        [HttpPut("update-name/{Id:int}")]
        //[Route("{Id:int}")]
        public IActionResult UpdateEmployeesName(int Id, UpdateEmployeeNameDto updateEmployeeNameDto)
        {
            var employeeEntity = _context.Employess.Find(Id);
            if (employeeEntity != null)
            {
                employeeEntity.Name = updateEmployeeNameDto.Name;

                _context.SaveChanges();
                return Ok(employeeEntity);
                
            }
            else
            {
                return NotFound($"Employee with Id {Id} not found.");
            }
            
        }

        [HttpPut("update-number/{Id:int}")]
        //[Route("{Id:int}")]
        public IActionResult UpdateEmployeesNumber(int Id, UpdateEmployeePhoneNumberDto updateEmployeePhoneNumberDto)
        {
            var employeeEntity = _context.Employess.Find(Id);
            if (employeeEntity != null)
            {
                employeeEntity.PhoneNumber = updateEmployeePhoneNumberDto.PhoneNumber;

                _context.SaveChanges();
                return Ok(employeeEntity);

            }
            else
            {
                throw new NotFoundException($"Employee with Id {Id} not found.");
            }

        }
    }
}
