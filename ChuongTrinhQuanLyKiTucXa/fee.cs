//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChuongTrinhQuanLyKiTucXa
{
    using System;
    using System.Collections.Generic;
    
    public partial class fee
    {
        public int id { get; set; }
        public string fmonth { get; set; }
        public double RoomPrice { get; set; }
        public double ElectricPrice { get; set; }
        public double NetPrice { get; set; }
    
        public virtual newStudent newStudent { get; set; }
    }
}
