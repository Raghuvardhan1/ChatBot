﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace chatbotrepo.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChatbotEntities : DbContext
    {
        public ChatbotEntities()
            : base("name=ChatbotEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomersTbl> CustomersTbls { get; set; }
        public virtual DbSet<InterestsTbl> InterestsTbls { get; set; }
        public virtual DbSet<MonitorsTbl> MonitorsTbls { get; set; }
        public virtual DbSet<OptionsTbl> OptionsTbls { get; set; }
        public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }
        public virtual DbSet<QuestionsTbl> QuestionsTbls { get; set; }
    }
}
