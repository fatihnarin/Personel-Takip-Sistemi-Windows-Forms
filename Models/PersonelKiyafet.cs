//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelTakipSistemi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonelKiyafet
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int DepartmanId { get; set; }
        public string IstekNedeni { get; set; }
        public string Renk { get; set; }
        public int Model { get; set; }
        public string UstBedenNo { get; set; }
        public string AltBedenNo { get; set; }
        public string KafaBedenNo { get; set; }
        public string AyakkabiNo { get; set; }
        public Nullable<int> Boy { get; set; }
        public Nullable<int> Kilo { get; set; }
    
        public virtual PersonelOzlukBilgileri PersonelOzlukBilgileri { get; set; }
    }
}
