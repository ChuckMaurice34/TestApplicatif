using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicatif.Models
{
    public class Ledger
    {
        #region Propriétés

        [Key]
        public int Id { get; set; }

        public int EntryId { get; set; }

        public int AccountId { get; set; }

        public int Amount { get; set; }

        #endregion
    }
}
