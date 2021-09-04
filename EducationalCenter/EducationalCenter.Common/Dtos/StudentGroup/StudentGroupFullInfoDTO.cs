using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.StudentGroup
{
    public class StudentGroupFullInfoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ErrorMessages.TitleLength)]
        public string Title { get; set; }

        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int StartYear { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int EndingYear { get; set; }
    }
}
