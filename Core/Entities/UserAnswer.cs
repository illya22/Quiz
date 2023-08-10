﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserAnswer : BaseEntity
    {
        public int UserId { get; set; }
        public int AnswerOptionsId { get; set; }
        public DateTime Date { get; set; }
    }
}
