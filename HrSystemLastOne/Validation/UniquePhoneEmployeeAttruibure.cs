﻿using System.ComponentModel.DataAnnotations;
using HrSystemLastOne.DTO;
using HrSystemLastOne.Models;

namespace HrSystemLastOne.Validation
{
    public class UniquePhoneEmployeeAttruibure : ValidationAttribute
    {


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //get value
            string Phone = (string)value;
            AddEmployeeDTO empValid = validationContext.ObjectInstance as AddEmployeeDTO;
            ITIContext _context = new ITIContext();

            Employee EmpValidDb = _context.Employees.FirstOrDefault(e => e.phone == Phone);

            if (EmpValidDb == null)
            {
                return ValidationResult.Success;
            }
            else if (EmpValidDb.Id == empValid.Id)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Phone Number already Found");
        }
    }

}
