﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestOgSikkerhedApp.Server;

#nullable disable

namespace TestOgSikkerhedApp.Migrations.TodoItem
{
    [DbContext(typeof(TodoItemContext))]
    partial class TodoItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestOgSikkerhedApp.Data.CprUser", b =>
                {
                    b.Property<int>("cprId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cprId"));

                    b.Property<int>("cprNum")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cprId");

                    b.ToTable("Cprs");
                });

            modelBuilder.Entity("TestOgSikkerhedApp.Data.ToDoItem", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<int?>("CprUsercprId")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemId");

                    b.HasIndex("CprUsercprId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("TestOgSikkerhedApp.Data.ToDoItem", b =>
                {
                    b.HasOne("TestOgSikkerhedApp.Data.CprUser", null)
                        .WithMany("toDoItems")
                        .HasForeignKey("CprUsercprId");
                });

            modelBuilder.Entity("TestOgSikkerhedApp.Data.CprUser", b =>
                {
                    b.Navigation("toDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
