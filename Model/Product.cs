using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
   public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name="Prodcuct Name")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }
    }
}
