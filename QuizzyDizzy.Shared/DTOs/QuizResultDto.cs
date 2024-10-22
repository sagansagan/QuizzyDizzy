﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzyDizzy.Shared.DTOs
{
    public class QuizResultDto
    {
        public int QuizId { get; set; }
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public int Score { get; set; }
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
        public string? QuizTitle { get; set; }
    }
}
