﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hostelEntities1 : DbContext
    {
        public hostelEntities1()
            : base("name=hostelEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fee> fees { get; set; }
        public virtual DbSet<newStudent> newStudents { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
