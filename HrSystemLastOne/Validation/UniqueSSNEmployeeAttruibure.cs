﻿using System.ComponentModel.DataAnnotations;
using HrSystemLastOne.DTO;
using HrSystemLastOne.Models;

namespace HrSystemLastOne.Validation
{
    public class UniqueSSNEmployeeAttruibure : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           

        //get value
            long SSN = (long)value;
            AddEmployeeDTO empValid = validationContext.ObjectInstance as AddEmployeeDTO;

            ITIContext _context = new ITIContext();
            Employee EmpValidDb = _context.Employees.SingleOrDefault(e => e.SSN == SSN);

            if (EmpValidDb == null)
            {
                return ValidationResult.Success;
            }
            else if (EmpValidDb.Id == empValid.Id)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("SSN already Found");
        }
    }
}
