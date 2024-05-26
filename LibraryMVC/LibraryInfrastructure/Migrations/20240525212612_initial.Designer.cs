﻿// <auto-generated />
using LibraryDomain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryInfrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240525212612_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryDomain.Model.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("LibraryDomain.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryDomain.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Administratorid")
                        .HasColumnType("int");

                    b.Property<int>("Authorid")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genreid")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Administratorid");

                    b.HasIndex("Authorid");

                    b.HasIndex("Genreid");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("LibraryDomain.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("LibraryDomain.Model.Possession", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Bookid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.HasIndex("Userid");

                    b.ToTable("Possessions");
                });

            modelBuilder.Entity("LibraryDomain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryDomain.Model.Book", b =>
                {
                    b.HasOne("LibraryDomain.Model.Administrator", "Administrator")
                        .WithMany("Books")
                        .HasForeignKey("Administratorid")
                        .IsRequired()
                        .HasConstraintName("FK_Book_Administrators");

                    b.HasOne("LibraryDomain.Model.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("Authorid")
                        .IsRequired()
                        .HasConstraintName("FK_Book_Authors");

                    b.HasOne("LibraryDomain.Model.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("Genreid")
                        .IsRequired()
                        .HasConstraintName("FK_Book_Genres");

                    b.Navigation("Administrator");

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryDomain.Model.Possession", b =>
                {
                    b.HasOne("LibraryDomain.Model.Book", "Book")
                        .WithMany("Possessions")
                        .HasForeignKey("Bookid")
                        .IsRequired()
                        .HasConstraintName("FK_Possessions_Book");

                    b.HasOne("LibraryDomain.Model.User", "User")
                        .WithMany("Possessions")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("FK_Possessions_Users");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryDomain.Model.Administrator", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryDomain.Model.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryDomain.Model.Book", b =>
                {
                    b.Navigation("Possessions");
                });

            modelBuilder.Entity("LibraryDomain.Model.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryDomain.Model.User", b =>
                {
                    b.Navigation("Possessions");
                });
#pragma warning restore 612, 618
        }
    }
}