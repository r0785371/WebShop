using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class ShoppingBag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingBagId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Order date")]
        public DateTime Date { get; set; }

        //FK CustomerId
        public int CustomerId { get; set; }
        [DisplayName("Customer")]
        public Customer Customer { get; set; }
        
        //FK ShoppingItemId => can be null
        [DisplayName("ShoppingItem")]
        [DisplayFormat(NullDisplayText ="There is no item")]
        public int? ShoppingItemId { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; }

        //not mapped = not saved in database
        //decimal 9,2 => 9 digits & 2 digits after komma

        [NotMapped]
        public int TotaalQuantity { get; set; }

        [NotMapped]
        [Column(TypeName ="decimal(9,2)")]
        public decimal SubTotaal { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(9,2)")]
        public decimal DiscountPercentage { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(9,2)")]
        public decimal DiscountValue { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Totaal { get; set; }

    }
}
