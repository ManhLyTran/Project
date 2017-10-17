using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVKTQS.Entities
{
    public class EventFile_DTO
    {
        public int EventFileID { get; set; }
        public int GeneralEventID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
    }
}