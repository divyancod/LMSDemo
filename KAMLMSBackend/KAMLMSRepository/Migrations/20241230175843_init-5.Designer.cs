﻿// <auto-generated />
using System;
using KAMLMSRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KAMLMSRepository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241230175843_init-5")]
    partial class init5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KAMLMSContracts.Entities.CallScheduleEntity", b =>
                {
                    b.Property<int>("CallScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CallScheduleId"));

                    b.Property<int>("CallStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("CallerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduledAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ScheduledById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ScheduledForId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ScheduledWithId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CallScheduleId");

                    b.HasIndex("CallStatusId");

                    b.HasIndex("CallerId");

                    b.HasIndex("ScheduledById");

                    b.HasIndex("ScheduledForId");

                    b.HasIndex("ScheduledWithId");

                    b.ToTable("tbl_call_schedule_history");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.CallStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_call_status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Scheduled"
                        },
                        new
                        {
                            Id = 2,
                            Status = "ReScheduled"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            Status = "Waiting"
                        },
                        new
                        {
                            Id = 5,
                            Status = "Answered"
                        },
                        new
                        {
                            Id = 6,
                            Status = "NotAnswered"
                        },
                        new
                        {
                            Id = 7,
                            Status = "Cancelled"
                        });
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.ContactEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeadsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("CustomRoleId");

                    b.HasIndex("LeadsId");

                    b.HasIndex("RoleId");

                    b.ToTable("tbl_poc_contacts");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeZoneAbbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UtcOffset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_country_time_zones");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.CustomRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_poc_custom_roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DEFAULT"
                        });
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.LeadStatusEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("tbl_status");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Status = "New"
                        },
                        new
                        {
                            id = 2,
                            Status = "InProgress"
                        },
                        new
                        {
                            id = 3,
                            Status = "FollowUp"
                        },
                        new
                        {
                            id = 4,
                            Status = "ClosedWon"
                        },
                        new
                        {
                            id = 5,
                            Status = "ClosedLost"
                        });
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.LeadsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ParentEnterpriseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHourEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkingHourStart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("StatusId");

                    b.ToTable("tbl_leads_information");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.LoginEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tbl_master_login");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.ManagersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tbl_kam_users");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.RolesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_poc_roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Director"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 4,
                            Name = "SalesManager"
                        },
                        new
                        {
                            Id = 5,
                            Name = "AssistantManager"
                        },
                        new
                        {
                            Id = 6,
                            Name = "OperationsManager"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Receptionist"
                        },
                        new
                        {
                            Id = 8,
                            Name = "BarManager"
                        },
                        new
                        {
                            Id = 9,
                            Name = "CustomerServiceManager"
                        },
                        new
                        {
                            Id = 10,
                            Name = "ITAuthority"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Custom"
                        });
                });

            modelBuilder.Entity("KAMLMSContracts.ResponseModels.DashboardResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentEnterpriseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DashboardResponse");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.CallScheduleEntity", b =>
                {
                    b.HasOne("KAMLMSContracts.Entities.CallStatusEntity", "CallStatus")
                        .WithMany()
                        .HasForeignKey("CallStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.ManagersEntity", "Caller")
                        .WithMany()
                        .HasForeignKey("CallerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.ManagersEntity", "ScheduledBy")
                        .WithMany()
                        .HasForeignKey("ScheduledById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.LeadsEntity", "ScheduledFor")
                        .WithMany()
                        .HasForeignKey("ScheduledForId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.ContactEntity", "ScheduledWith")
                        .WithMany()
                        .HasForeignKey("ScheduledWithId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CallStatus");

                    b.Navigation("Caller");

                    b.Navigation("ScheduledBy");

                    b.Navigation("ScheduledFor");

                    b.Navigation("ScheduledWith");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.ContactEntity", b =>
                {
                    b.HasOne("KAMLMSContracts.Entities.ManagersEntity", "ManagersEntity")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.CustomRoleEntity", "CustomRole")
                        .WithMany()
                        .HasForeignKey("CustomRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.LeadsEntity", "LeadsEntity")
                        .WithMany()
                        .HasForeignKey("LeadsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KAMLMSContracts.Entities.RolesEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomRole");

                    b.Navigation("LeadsEntity");

                    b.Navigation("ManagersEntity");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KAMLMSContracts.Entities.LeadsEntity", b =>
                {
                    b.HasOne("KAMLMSContracts.Entities.ManagersEntity", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById");

                    b.HasOne("KAMLMSContracts.Entities.ManagersEntity", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("KAMLMSContracts.Entities.LeadStatusEntity", "status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedBy");

                    b.Navigation("AssignedTo");

                    b.Navigation("status");
                });
#pragma warning restore 612, 618
        }
    }
}
