using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BookStore.App.Data.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Isbn { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        public DateTime PublishedAt { get; set; }

        public string UserId { get; set; }
        public IdentityUser User { get; set; }

    }

}

