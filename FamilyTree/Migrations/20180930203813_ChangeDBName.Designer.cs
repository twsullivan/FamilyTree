﻿// <auto-generated />
using System;
using FamilyTree.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyTree.Migrations
{
    [DbContext(typeof(FamilyTreeContext))]
    [Migration("20180930203813_ChangeDBName")]
    partial class ChangeDBName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyTree.Models.ParentChildren", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChildId");

                    b.HasKey("ParentId");

                    b.ToTable("ParentChildren");
                });

            modelBuilder.Entity("FamilyTree.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("Death");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Middlename");

                    b.Property<int?>("ParentChildrenParentId");

                    b.HasKey("PersonId");

                    b.HasIndex("ParentChildrenParentId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("FamilyTree.Models.Person", b =>
                {
                    b.HasOne("FamilyTree.Models.ParentChildren", "ParentChildren")
                        .WithMany("Children")
                        .HasForeignKey("ParentChildrenParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
