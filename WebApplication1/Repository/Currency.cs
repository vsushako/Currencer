using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    [Table("Currency")]
    public class Currency : ICurrency
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name_from")]
        public string NameFrom { get; set; }

        [Column("name_to")]
        public string NameTo { get; set; }

        [Column("code_from")]
        public string CodeFrom { get; set; }

        [Column("code_to")]
        public string CodeTo { get; set; }
    }
}