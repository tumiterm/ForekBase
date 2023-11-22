using ForekBase.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Domain.Entities
{
    public class SurveyResponse : BaseEntityModel
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public int UserId { get; set; } // Reference to the user who completed the survey
        public User User { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
