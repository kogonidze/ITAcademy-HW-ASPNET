using EducationalCenter.Common.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.StudentGroup
{
    public class StudentGroupCreationDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ErrorMessages.TitleLength)]
        public string Title { get; set; }

        public int? FacultyId { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int StartYear { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int EndingYear { get; set; }
    }
}
