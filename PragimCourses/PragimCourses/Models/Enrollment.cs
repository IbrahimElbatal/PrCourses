﻿using System;

namespace PragimCourses.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }

        public ApplicationUser User { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}