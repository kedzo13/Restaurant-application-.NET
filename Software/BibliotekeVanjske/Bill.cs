//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotekeVanjske
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        public int BrRacuna { get; set; }
        public int Narudzba { get; set; }
        public string ImeZaposlenika { get; set; }
        public System.DateTime Vrijeme { get; set; }
        public string VrstaPlacanja { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
