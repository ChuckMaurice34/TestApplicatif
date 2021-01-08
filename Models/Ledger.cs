using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicatif.Models
{
    [Table("Ledger")]
    public class Ledger
    {
        #region Propriétés

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("EntryId")]
        public int EntryId { get; set; }

        [Column("AccountId")]
        public int AccountId { get; set; }

        [Column("Amount")]
        public int Amount { get; set; }

        #endregion
    }
}
