using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos.StudentGroup;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentFullInfoDTO
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

        public int? GroupId { get; set; }

        public StudentGroupDTO Group { get; set; }
    }
}
