//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jour6_EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statut()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int ID { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public byte[] upsize_ts { get; set; }
    
        public virtual Bug Bug { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}