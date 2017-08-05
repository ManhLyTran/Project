using System;
using System.ComponentModel.DataAnnotations;

namespace HVKTQS.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? CreatedDate { set; get; }

        [MaxLength(255)]
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(255)]
        public string UpdatedBy { set; get; }
    }
}