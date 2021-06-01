using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Data.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
