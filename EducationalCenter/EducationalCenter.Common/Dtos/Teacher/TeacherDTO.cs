using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.Teacher
{
    public class TeacherDTO
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Experience { get; set; }

        public Category Category { get; set; }

        public Formation Formation { get; set; }
    }
}

