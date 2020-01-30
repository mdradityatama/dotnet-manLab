using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManLab.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string Name { get; set; }
        public List<Collection> Collections { get; set; }

        public Room()
        {
            this.Collections = new List<Collection>();
        }
    }
}
