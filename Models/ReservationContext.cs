using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Reservation;

namespace Reservation
{
    public class ReservationContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<ResourceGroup> ResourceGroups { get; set; }
        public DbSet<ResourceSource> ResourceSources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        

        public ReservationContext(DbContextOptions<ReservationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        private void LoadData(ModelBuilder modelBuilder) {
            var resources = new List<Resource>();
            var groups = new List<ResourceGroup>();

            var rt_employees = new ResourceType("Сотрудники");
            var rt_parkingSpaces = new ResourceType("Парковочные места");
            var rt_meetingRooms = new ResourceType("Переговорные комнаты");
            var rt_transports = new ResourceType("Корпоративный транспорт");
            var rt_officeEquipment = new ResourceType("Офисная техника");

            var rootGroup = new ResourceGroup("Неверленд", null);
            groups.Add(rootGroup);
            var source = new ResourceSource("Active Directory");            

            var owner = new Resource("Дарт Вейдер", rt_employees.Id, rootGroup.Id, source.Id, null, null);
            resources.Add(owner);
            var decisionMaker = new Resource("Ганнибал Лектер", rt_employees.Id, rootGroup.Id, source.Id, null, null);
            resources.Add(decisionMaker);

            for (int i = 1; i <= 5; i++)
            {
                var group = new ResourceGroup($"Этаж №{i}", rootGroup.Id);
                groups.Add(group);
                for (int j = 1; j < 10; j++)
                {
                    var resource = new Resource($"Парковочное место №{i}{j}", rt_parkingSpaces.Id, group.Id, source.Id, decisionMaker.Id, owner.Id);
                    resources.Add(resource);
                }
            }

            for (int i = 1; i <= 10; i++)
            {
                var group = new ResourceGroup($"Этаж №{i}", rootGroup.Id);
                groups.Add(group);
                for (int j = 1; j < 10; j++)
                {
                    var resource = new Resource($"Переговорная комната №{i}{j}", rt_meetingRooms.Id, group.Id, source.Id, decisionMaker.Id, owner.Id);
                    resources.Add(resource);
                }
            }

            modelBuilder.Entity<ResourceType>().HasData
            (
                rt_employees,
                rt_parkingSpaces,
                rt_meetingRooms,
                rt_officeEquipment,
                rt_transports
            );

            for (int i = 0; i < 100; i++)
            {
                for (char letter = 'A'; letter <= 'Z'; letter++)
                {
                    resources.Add(new Resource($"Дроид {letter}-{i}", rt_employees.Id, rootGroup.Id, source.Id, decisionMaker.Id, owner.Id));                    
                }
            }           

            modelBuilder.Entity<ResourceGroup>().HasData(groups);
            modelBuilder.Entity<ResourceSource>().HasData(source);
            modelBuilder.Entity<Resource>().HasData(resources);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<RequestStatus>()
                .ToTable("RequestStatuses")
                .HasKey(p => p.Id)
                .HasName("PK_RequestStatus");

            modelBuilder.Entity<ResourceType>()
                .ToTable("ResourceTypes")
                .HasKey(p => p.Id)
                .HasName("PK_ResourceType");


            modelBuilder.Entity<Notification>()
                .ToTable("Notifications")
                .HasKey(p => p.Id)
                .HasName("PK_Notification");
            modelBuilder.Entity<Notification>()
                .HasOne(r => r.Recipient)
                .WithMany()
                .HasForeignKey(r => r.RecipientId);
            
            modelBuilder.Entity<ResourceGroup>()
                .ToTable("ResourceGroups")
                .HasKey(p => p.Id)
                .HasName("PK_ResourceGroup");
            modelBuilder.Entity<ResourceGroup>()
                .HasOne(r => r.Parent)
                .WithMany()
                .HasForeignKey(r => r.ParentId);

            
            modelBuilder.Entity<ResourceSource>()
                .ToTable("ResourceSources")
                .HasKey(p => p.Id)
                .HasName("PK_ResourceSource");


            modelBuilder.Entity<Resource>()
                .ToTable("Resources")
                .HasKey(p => p.Id)
                .HasName("PK_Resource");
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Owner)
                .WithMany()
                .HasForeignKey(r => r.OwnerId);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.DecisionMaker)
                .WithMany()
                .HasForeignKey(r => r.DecisionMakerId);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Type)
                .WithMany()
                .HasForeignKey(r => r.TypeId);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Group)
                .WithMany()
                .HasForeignKey(r => r.GroupId);
            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Source)
                .WithMany()
                .HasForeignKey(r => r.SourceId);
            
            
            
            modelBuilder.Entity<LogRecord>()
                .ToTable("LogRecords")
                .HasKey(p => p.Id)
                .HasName("PK_LogRecord");
            modelBuilder.Entity<LogRecord>()
                .HasOne(r => r.Request)
                .WithMany()
                .HasForeignKey(r => r.RequestId);

            modelBuilder.Entity<Request>()
                .ToTable("Requests")
                .HasKey(p => p.Id)
                .HasName("PK_Request");
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Holder)
                .WithMany()
                .HasForeignKey(r => r.HolderId);
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Status)
                .WithMany()
                .HasForeignKey(r => r.StatusId);

            #region RequestResource
            modelBuilder.Entity<RequestResource>()
                .HasKey(rr => new { rr.RequestId, rr.ResourceId })
                .HasName("PK_RequestResource");

            modelBuilder.Entity<RequestResource>()
                .HasOne(pt => pt.Request)
                .WithMany(p => p.Resources)
                .HasForeignKey(pt => pt.RequestId);

            modelBuilder.Entity<RequestResource>()
                .HasOne(pt => pt.Resource)
                .WithMany(t => t.Requests)
                .HasForeignKey(pt => pt.ResourceId);
            #endregion

            LoadData(modelBuilder);
        }
    }
}
