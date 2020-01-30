using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManLab.Models
{
    public class Tool
    {
        [Key]
        public int ToolID { get; set; }
        public string Name { get; set; }
        public List<Collection> Collections { get; set; }
        public Tool()
        {
            this.Collections = new List<Collection>();
        }
    }
}
