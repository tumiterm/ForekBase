using ForekBase.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Domain.Entities
{
    public class Survey : BaseEntityModel
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}
