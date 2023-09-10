using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public virtual Question? Question { get; set; }

        public bool IsCorrect { get; set; } = false;
    }
}
