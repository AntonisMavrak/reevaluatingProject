﻿// <auto-generated />
using System;
using ADOPSEV1._1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADOPSEV1._1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ADOPSEV1._1.Models.Anwser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("isCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("anwsers");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.Branch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("branches");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.Lesson", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.Question", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("madeBy")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.QuestionAwsers", b =>
                {
                    b.Property<int>("anwserId")
                        .HasColumnType("int");

                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.ToTable("questionAwsers");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.Quiz", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("madeBy")
                        .HasColumnType("int");

                    b.Property<int>("minutes")
                        .HasColumnType("int");

                    b.Property<int>("numberOfQuestions")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("id");

                    b.ToTable("quizzes");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.QuizQuestions", b =>
                {
                    b.Property<int>("questionId")
                        .HasColumnType("int");

                    b.Property<int>("quizId")
                        .HasColumnType("int");

                    b.ToTable("quizQuestions");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.Subject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("branchId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("role")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("validated")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.UserConntectsSubject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("lessonId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("userConnectsSubjects");
                });

            modelBuilder.Entity("ADOPSEV1._1.Models.UserFinishedQuizzes", b =>
                {
                    b.Property<int>("quizId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.ToTable("userFinishedQuizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
