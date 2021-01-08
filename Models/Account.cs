using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplicatif.Models
{
    [Table("Account")]
    public class Account
    {
        #region Propriétés

        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Number")]
        public int Number { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        #endregion
    }
}
