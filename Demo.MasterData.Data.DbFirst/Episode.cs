//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.MasterData.Data.DbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Episode
    {
        public Episode()
        {
            this.Visits = new HashSet<Visit>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Patient_Id { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}