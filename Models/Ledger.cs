//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApplicatif.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ledger
    {
        public long Id { get; set; }
        public Nullable<long> EntryId { get; set; }
        public Nullable<long> AccountId { get; set; }
        public Nullable<double> Amount { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Entry Entry { get; set; }
    }
}
