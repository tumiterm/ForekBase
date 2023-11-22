using ForekBase.Domain.Entities.Common;
using ForekBase.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Domain.Entities
{
    public class Question : BaseEntityModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
