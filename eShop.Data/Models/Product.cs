﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Data.Enums;

namespace eShop.Data.Models
{
    [Table("Product")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProductCount { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "#,###")]
        public float UnitPrice { get; set; }

        public float? PromotionPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }

        public IList<ProductCategory> ProductCategories { get; set; }

        public IList<ProductImage> ProductImages { get; set; }
    }
}
