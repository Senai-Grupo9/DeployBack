using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai_fabNew.webAPI.Domains;

namespace Senai_fabNew.webAPI.Contexts
{
    public partial class FabSenaiNewContext : DbContext
    {
        public FabSenaiNewContext()
        {
        }

        public FabSenaiNewContext(DbContextOptions<FabSenaiNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<RegistroObjeto> RegistroObjetos { get; set; }
        public virtual DbSet<RegistroPessoa> RegistroPessoas { get; set; }
        public virtual DbSet<TipoObjeto> TipoObjetos { get; set; }
        public virtual DbSet<TipoUser> TipoUsers { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=tcp:fabsenai.database.windows.net,1433;Initial Catalog=DB-FAB;User Id=SenaiFab@fabsenai;Password=Senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PK__pessoa__7061465DD5B29D06");

                entity.ToTable("pessoa");

                entity.Property(e => e.IdPessoa).ValueGeneratedOnAdd();

                entity.Property(e => e.Faceid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("faceid");

                entity.Property(e => e.Imagem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Verificado).HasColumnName("verificado");
            });

            modelBuilder.Entity<RegistroObjeto>(entity =>
            {
                entity.HasKey(e => e.IdRegistroObj)
                    .HasName("PK__registro__AE878767876A4F2D");

                entity.ToTable("registroObjeto");

                entity.Property(e => e.IdRegistroObj).ValueGeneratedOnAdd();

                entity.Property(e => e.CheckIn)
                    .HasColumnType("datetime")
                    .HasColumnName("checkIn");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOut");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.RegistroObjetos)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__registroO__IdPes__619B8048");

                entity.HasOne(d => d.IdTipoObjNavigation)
                    .WithMany(p => p.RegistroObjetos)
                    .HasForeignKey(d => d.IdTipoObj)
                    .HasConstraintName("FK__registroO__IdTip__60A75C0F");
            });

            modelBuilder.Entity<RegistroPessoa>(entity =>
            {
                entity.HasKey(e => e.IdRegistroPessoa)
                    .HasName("PK__registro__C701218FECA38D10");

                entity.ToTable("registroPessoa");

                entity.Property(e => e.IdRegistroPessoa).ValueGeneratedOnAdd();

                entity.Property(e => e.CheckIn)
                    .HasColumnType("datetime")
                    .HasColumnName("checkIn");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("datetime")
                    .HasColumnName("checkOut");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.RegistroPessoas)
                    .HasForeignKey(d => d.IdPessoa)
                    .HasConstraintName("FK__registroP__IdPes__6477ECF3");
            });

            modelBuilder.Entity<TipoObjeto>(entity =>
            {
                entity.HasKey(e => e.IdTipoObj)
                    .HasName("PK__tipoObje__23E92BDB9346DE01");

                entity.ToTable("tipoObjeto");

                entity.Property(e => e.IdTipoObj).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<TipoUser>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TipoUser__9E3A29A57785DD5E");

                entity.ToTable("TipoUser");

                entity.Property(e => e.IdTipo).ValueGeneratedOnAdd();

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Usuario__B7C9263876DCBA5B");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Senha)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuario__IdTipo__693CA210");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
