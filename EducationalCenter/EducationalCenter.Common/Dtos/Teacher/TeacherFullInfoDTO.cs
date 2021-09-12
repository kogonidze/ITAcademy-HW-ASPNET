using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.Teacher
{
    public class TeacherFullInfoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessages.NameLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = ErrorMessages.NameLength)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = ErrorMessages.Email)]
        public string EMail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = ErrorMessages.MobilePhone)]
        public string PhoneNumber { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = ErrorMessages.IncorrectExperience)]
        public int Experience { get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = ErrorMessages.NotExistInEnum)]
        public Category Category { get; set; }

        [Required]
        [EnumDataType(typeof(Formation), ErrorMessage = ErrorMessages.NotExistInEnum)]
        public Formation Formation { get; set; }

        public int Salary { get; set; }
    }
}
