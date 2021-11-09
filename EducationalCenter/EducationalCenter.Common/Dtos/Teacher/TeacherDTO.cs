using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using System;
using System.Collections.Generic;

namespace EducationalCenter.Common.Dtos
{
    public class TeacherDTO
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public int Experience { get; set; }

        public Category Category { get; set; }

        public Formation Formation { get; set; }

        public override bool Equals(object obj)
        {
            return obj is TeacherDTO dTO &&
                   Id == dTO.Id &&
                   FIO == dTO.FIO &&
                   DateOfBirth == dTO.DateOfBirth &&
                   DepartmentId == dTO.DepartmentId &&
                   Experience == dTO.Experience &&
                   Category == dTO.Category &&
                   Formation == dTO.Formation;
        }
    }
}

