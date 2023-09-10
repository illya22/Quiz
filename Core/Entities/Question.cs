using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Question : BaseEntity<int>
    {
        public string Content { get; set; } = string.Empty;

        public IEnumerable<Answer> Options { get; set; }

        public int QuizId { get; set; }

        [ForeignKey(nameof(QuizId))]
        public virtual Quiz? Quiz { get; set; }

        public Question()
        {
            Options = new List<Answer>();
        }
    }
}
