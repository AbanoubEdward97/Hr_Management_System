﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HrSystemLastOne.Validation;

namespace HrSystemLastOne.Models
{
    public class Employee
    {

        public int Id { get; set; }


        //[UniqueSSNEmployeeAttruibure]
        [RegularExpression(@"^\d{14}$", ErrorMessage = "Invalid SSN number, the SSN number should contain 14 digits")]
        public long SSN { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Nationality { get; set; }
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be Male Or Female")]
        public string Gender { get; set; }

        [UniquePhoneEmployeeAttruibure]
        //[RegularExpression(@"^(10|11|12|13|15)\[0-9]{8}$", ErrorMessage = "Invalid phone number, please enter valid phone number")]
        [RegularExpression(@"^01[1235][0-9]{8}$", ErrorMessage = "Invalid phone number, please enter valid phone number")]
        [MinLength(11)]
        public string phone { get; set; }


        [MinLength(3)]
        public string City { get; set; }
        [MinLength(3)]
        public string Country { get; set; }
        [MinLength(3)]
        public string street { get; set; }


        [Range(1000, 100000)]
        public int Salary { get; set; }

        [HiredateEmployeeAttribute]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime HireDate { get; set; }


        [AgeEmployee]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
      
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        public TimeSpan LeaveTime { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh-mm}")]
        [Required]
        [AttendLeaveTime("AttendTime", "LeaveTime")]
        public TimeSpan AttendTime { get; set; }



        [ForeignKey("Department")]
        public int Dept_id { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<LeaveAttend> LeaveAttends { get; set; } = new List<LeaveAttend>();



    }
}
