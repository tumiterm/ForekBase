using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForekBase.Domain.Entities.Common
{
    public class BaseEntityModel
    {
        public string CreateBy { get; set; }    
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }    
        public bool IsActive { get; set; }

    }
}
