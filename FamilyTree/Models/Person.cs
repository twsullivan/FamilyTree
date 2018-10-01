using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyTree.Models
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext() : base() { }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FamilyTreeDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relation>()
                .HasKey(e => new { e.ParentId, e.ChildId });

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Relation>()
                .HasOne(e => e.Child)
                .WithMany(e => e.Parents)
                .HasForeignKey(e => e.ChildId);
        }
    }
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime Death { get; set; }
        public virtual ICollection<Relation> Parents { get; set; }
        public virtual ICollection<Relation> Children { get; set; }
    }

    public class Relation
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public virtual Person Parent { get; set; }
        public virtual Person Child { get; set; }
    }
}

