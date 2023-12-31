﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NganHangNhaTro.Models;

public partial class dbContext : DbContext
{
    public dbContext()
    {

    }
    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Motel> Motel { get; set; }
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=YISUS\\SQLEXPRESS;Database=NganHangNhaTro;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Motel>()
            .HasOne(m => m.user)
            .WithMany(u => u.motels)
            .HasForeignKey(m => m.created_by);
    }

    // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
