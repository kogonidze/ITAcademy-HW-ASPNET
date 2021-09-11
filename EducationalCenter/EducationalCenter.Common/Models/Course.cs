﻿using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int HoursCount { get; set; }

        public ControlForm ControlForm { get; set; }
    }
}
