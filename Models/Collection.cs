using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManLab.Models
{
    public class Collection
    {
        [Key]
        public int CollectionID { get; set; }
        public int ToolID { get; set; }
        public int CategoryID { get; set; }
        public int RoomID { get; set; }
        public int Total { get; set; }
        public Tool Tool { get; set; }
        public Category Category { get; set; }
        public Room Room { get; set; }

    }
}
