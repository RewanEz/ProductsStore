using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductStore.Domain.Product
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public double Price { get; set; }

        private DateTime? lastupdate;

        [Column(TypeName = "datetime")]
        public DateTime Lastupdate => lastupdate ??= DateTime.Now;
        public string PhotoUrl { get; set; }

    }
}
