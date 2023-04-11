using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace POS.Domain.Entities
{
    public partial class POSContext : DbContext
    {
        public POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchOffice> BranchOffices { get; set; } = null!;
        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuRole> MenuRoles { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Purcharse> Purcharses { get; set; } = null!;
        public virtual DbSet<PurcharseDetail> PurcharseDetails { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleDetail> SaleDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UsersBranchOffice> UsersBranchOffices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UKDCDPL\\WAR;Database=POS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.BranchOffices)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BranchOff__Busin__48CFD27E");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.BranchOffices)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BranchOff__Distr__49C3F6B7");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Business");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Mision).IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Vision).IsUnicode(false);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Business__Distri__4AB81AF0");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clients__Documen__4BAC3F29");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Provinces");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<MenuRole>(entity =>
            {
                entity.HasKey(e => e.MenuRolId)
                    .HasName("PK__MenuRole__6640AD0C5B6993AF");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuRoles)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_MenuRoles_Menu");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MenuRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_MenuRoles_Roles");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SellPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Catego__4F7CD00D");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Provid__5070F446");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Providers__Docum__5165187F");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Provinces__Depar__52593CB8");
            });

            modelBuilder.Entity<Purcharse>(entity =>
            {
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Purcharses)
                    .HasForeignKey(d => d.ProviderId)
                    .HasConstraintName("FK__Purcharse__Provi__5535A963");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purcharses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Purcharse__UserI__5629CD9C");
            });

            modelBuilder.Entity<PurcharseDetail>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurcharseDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Purcharse__Produ__534D60F1");

                entity.HasOne(d => d.Purcharse)
                    .WithMany(p => p.PurcharseDetails)
                    .HasForeignKey(d => d.PurcharseId)
                    .HasConstraintName("FK__Purcharse__Purch__5441852A");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Sales__ClientId__59063A47");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Sales__UserId__59FA5E80");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__SaleDetai__Produ__571DF1D5");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK__SaleDetai__SaleI__5812160E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .HasConstraintName("FK__UserRoles__Branc__5AEE82B9");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__5CD6CB2B");
            });

            modelBuilder.Entity<UsersBranchOffice>(entity =>
            {
                entity.HasKey(e => e.UserBranchOfficeId)
                    .HasName("PK__UsersBra__7D1E804AA8EA56A4");

                entity.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.UsersBranchOffices)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .HasConstraintName("FK__UsersBran__Branc__5DCAEF64");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersBranchOffices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersBran__UserI__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
