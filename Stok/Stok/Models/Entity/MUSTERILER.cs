//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class MUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       
        public MUSTERILER()
        {
            this.SATISLAR = new HashSet<SATISLAR>();
        }
    
        public int MUSTERIID { get; set; }

        [Required (ErrorMessage ="Bu alan� bo� b�rakamazs�n�z.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakterlik isim girin")]

        public string MUSTERIAD { get; set; }
        [Required(ErrorMessage = "Bu alan� bo� b�rakamazs�n�z.")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakterlik isim girin")]

        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SATISLAR> SATISLAR { get; set; }
    }
}
