using System;
using System.ComponentModel.DataAnnotations;

namespace GradesService.Models
{
    public class Grade
    {
        [Key]
        public Guid Id { get; set; }
        
        public string ?SubjectName { get; set; }
        public string ?GradeName { get; set; }
        public double Value { get; set; }
        public string ?Comment { get; set; }
    }
}
