namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class onlineShop : DbContext
    {
        public onlineShop()
            : base("name=onlineShop26")
        {
        }

        public virtual DbSet<m_about> m_about { get; set; }
        public virtual DbSet<m_bill> m_bill { get; set; }
        public virtual DbSet<m_catetory> m_catetory { get; set; }
        public virtual DbSet<m_chat> m_chat { get; set; }
        public virtual DbSet<m_contact> m_contact { get; set; }
        public virtual DbSet<m_content> m_content { get; set; }
        public virtual DbSet<m_content_tag> m_content_tag { get; set; }
        public virtual DbSet<m_feedback> m_feedback { get; set; }
        public virtual DbSet<m_information> m_information { get; set; }
        public virtual DbSet<m_last_footer> m_last_footer { get; set; }
        public virtual DbSet<m_login> m_login { get; set; }
        public virtual DbSet<m_menu> m_menu { get; set; }
        public virtual DbSet<m_menutype> m_menutype { get; set; }
        public virtual DbSet<m_order_bill> m_order_bill { get; set; }
        public virtual DbSet<m_product> m_product { get; set; }
        public virtual DbSet<m_product_bill> m_product_bill { get; set; }
        public virtual DbSet<m_productCatetory> m_productCatetory { get; set; }
        public virtual DbSet<m_slide> m_slide { get; set; }
        public virtual DbSet<m_supplier> m_supplier { get; set; }
        public virtual DbSet<m_supplier_product> m_supplier_product { get; set; }
        public virtual DbSet<m_tag> m_tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<m_about>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<m_about>()
                .Property(e => e.CrratedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_about>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_about>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<m_bill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_bill>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<m_catetory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<m_catetory>()
                .Property(e => e.CrratedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_catetory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_catetory>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<m_content>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<m_content>()
                .Property(e => e.CrratedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_content>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_content>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<m_content>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<m_last_footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<m_order_bill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<m_product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_product>()
                .Property(e => e.ProductPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_product>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_product>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_product>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<m_product_bill>()
                .Property(e => e.shipPhone)
                .IsUnicode(false);

            modelBuilder.Entity<m_product_bill>()
                .Property(e => e.ShipAddress)
                .IsUnicode(false);

            modelBuilder.Entity<m_product_bill>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_productCatetory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<m_productCatetory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_productCatetory>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength();

            modelBuilder.Entity<m_slide>()
                .Property(e => e.CrratedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<m_supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<m_supplier_product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<m_tag>()
                .Property(e => e.Id)
                .IsUnicode(false);
        }
    }
}
