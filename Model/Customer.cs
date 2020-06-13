using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
   public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public string Firstname { get; set; }
        //FK ?=> can be null
        public int? ShoppingBagId { get; set; }
        public ICollection<ShoppingBag> ShoppingBags { get; set; }

    }
}
