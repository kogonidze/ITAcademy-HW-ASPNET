using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.StudentGroup
{
    public class StudentGroupFullInfoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ErrorMessages.TitleLength)]
        public string Title { get; set; }

        [Required]
        [EnumDataType(typeof(Faculty), ErrorMessage = ErrorMessages.NotExistInEnum)]
        public Faculty Faculty { get; set; }

        public int TeacherId { get; set; }

        public TeacherDTO Teacher { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int StartYear { get; set; }

        [Required]
        [Range(2000, 2050, ErrorMessage = ErrorMessages.IncorrectYear)]
        public int EndingYear { get; set; }
    }
}
