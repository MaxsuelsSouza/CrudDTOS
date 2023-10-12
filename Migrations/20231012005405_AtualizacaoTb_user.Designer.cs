﻿// <auto-generated />
using System;
using CrudDTOS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CrudDTOS.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20231012005405_AtualizacaoTb_user")]
    partial class AtualizacaoTb_user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CrudDTOS.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("CreateRegistration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createregistration");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("telefone");

                    b.Property<DateTime>("UpdateRegistration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updateRegistration");

                    b.HasKey("Id");

                    b.ToTable("tb_users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
