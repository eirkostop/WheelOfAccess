using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WheelofAccess.Models
{
    public class Category
    {
<<<<<<< Updated upstream
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
=======
        public Category()
        {
            TypesofPlace = new HashSet<Place>();
        }
        public int Id { get; set; }
>>>>>>> Stashed changes
        public string Name { get; set; }
        ICollection<Place> TypesofPlace { get; set; }
    }
}