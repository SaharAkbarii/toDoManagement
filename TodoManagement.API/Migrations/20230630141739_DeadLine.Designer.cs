﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TodoManagement.API.Repository;

#nullable disable

namespace TodoManagement.API.Migrations
{
    [DbContext(typeof(ToDoManagementDbContext))]
    [Migration("20230630141739_DeadLine")]
    partial class DeadLine
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TodoManagement.API.Model.ChangeTodoStatusHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("ChangedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("integer");

                    b.Property<Guid>("ToDoId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ToDoId");

                    b.ToTable("ChangeTodoStatusHistories");
                });

            modelBuilder.Entity("TodoManagement.API.Model.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TodoManagement.API.Model.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeadLine")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TodoManagement.API.Model.ToDo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ApprovedById")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ApprovedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("AssigneeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("StoryPoint")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("TodoManagement.API.Model.ChangeTodoStatusHistory", b =>
                {
                    b.HasOne("TodoManagement.API.Model.ToDo", "ToDo")
                        .WithMany("ChangeTodoStatusHistories")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDo");
                });

            modelBuilder.Entity("TodoManagement.API.Model.ToDo", b =>
                {
                    b.HasOne("TodoManagement.API.Model.Person", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedById");

                    b.HasOne("TodoManagement.API.Model.Person", "Assignee")
                        .WithMany("ToDos")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("TodoManagement.API.Model.Project", "Project")
                        .WithMany("ToDos")
                        .HasForeignKey("ProjectId");

                    b.Navigation("ApprovedBy");

                    b.Navigation("Assignee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TodoManagement.API.Model.Person", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("TodoManagement.API.Model.Project", b =>
                {
                    b.Navigation("ToDos");
                });

            modelBuilder.Entity("TodoManagement.API.Model.ToDo", b =>
                {
                    b.Navigation("ChangeTodoStatusHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
