﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class db_efileEntities : DbContext
{
    public db_efileEntities()
        : base("name=db_efileEntities")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<roles> roles { get; set; }
    public virtual DbSet<staff> staff { get; set; }
    public virtual DbSet<stafflogin> stafflogin { get; set; }
    public virtual DbSet<activity> activity { get; set; }
}