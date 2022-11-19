﻿using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int AttemptId { get; set; }
        public int QuestionId { get; set; }
        public string? TextAnswer { get; set; }
        public int? IntAnswer { get; set; }
        public double? DoubleAnswer { get; set; }
        public DateTime? DateAnswer { get; set; }
    }
}
