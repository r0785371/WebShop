using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
   public class ShoppingItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingItemId { get; set; }
        [Range(1,50)]
        public int Quantity { get; set; }
        
        //FK shoppingbag
        public int ShoppingBagId { get; set; }
        public ShoppingBag ShoppingBag { get; set; }

        //FK product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [NotMapped]
        [Column(TypeName ="decimal(9,2)")]
        public decimal SubTotaal { get; set; }
    }
}
