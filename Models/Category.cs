using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManLab.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Collection> Collections { get; set; }

        public Category()
        {
            this.Collections = new List<Collection>();
        }
    }
}
