﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Postgres.Infrastructure.Implementation.Database;

#nullable disable

namespace Postgres.Infrastructure.Implementation.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Postgres.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("SiteUri")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("site_uri");

                    b.HasKey("Id")
                        .HasName("pk_blogs");

                    b.ToTable("blogs", (string)null);
                });

            modelBuilder.Entity("Postgres.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("boolean")
                        .HasColumnName("archived");

                    b.Property<int>("BlogId")
                        .HasColumnType("integer")
                        .HasColumnName("blog_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("published_on");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_posts");

                    b.HasIndex("BlogId")
                        .HasDatabaseName("ix_posts_blog_id");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("Postgres.Domain.Entities.Post", b =>
                {
                    b.HasOne("Postgres.Domain.Entities.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_posts_blogs_blog_id");

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Postgres.Domain.Entities.Blog", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
