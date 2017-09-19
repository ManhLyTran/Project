using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HVKTQS.UI.Models
{
    public partial class EventFileViewModel
    {
        public int EventFileID { get; set; }

        public int? EventID { get; set; }

        public string FileName { get; set; }

        public long? FileSize { get; set; }

        public string FilePath { get; set; }

        public virtual EventViewModel Events { get; set; }
    }
}