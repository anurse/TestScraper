﻿// <auto-generated />
using System;
using Microsoft.AspNetCore.Internal.TestScraper.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Microsoft.AspNetCore.Internal.TestScraper.Migrations
{
    [DbContext(typeof(TestResultsDbContext))]
    [Migration("20200117061522_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Internal.TestScraper.Db.Pipeline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AzDoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Project", "AzDoId")
                        .IsUnique()
                        .HasFilter("[Project] IS NOT NULL");

                    b.ToTable("Pipelines");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Internal.TestScraper.Db.PipelineBuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AzDoId")
                        .HasColumnType("int");

                    b.Property<string>("BuildNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CompletedTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("PipelineId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SyncAttempts")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SyncCompleteUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SyncStartedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("WebUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PipelineId", "AzDoId")
                        .IsUnique();

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Internal.TestScraper.Db.PipelineTestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assembly")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuildId")
                        .HasColumnType("int");

                    b.Property<string>("Collection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailureMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FailureStackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Flaky")
                        .HasColumnType("bit");

                    b.Property<string>("FlakyOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Run")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkipReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Traits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildId");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Internal.TestScraper.Db.PipelineBuild", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Internal.TestScraper.Db.Pipeline", "Pipeline")
                        .WithMany("Builds")
                        .HasForeignKey("PipelineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Internal.TestScraper.Db.PipelineTestResult", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Internal.TestScraper.Db.PipelineBuild", "Build")
                        .WithMany("TestResults")
                        .HasForeignKey("BuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}