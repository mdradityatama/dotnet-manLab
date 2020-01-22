using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManLab.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string Name { get; set; }
        public List<Tool> Tools { get; set; }

        public Room()
        {
            this.Tools = new List<Tool>();
        }
    }
}
