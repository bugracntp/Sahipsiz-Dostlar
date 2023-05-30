namespace Sahipsiz_Dostlar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 100),
                        Sifre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Ilanlar",
                c => new
                    {
                        HayvanId = c.Int(nullable: false, identity: true),
                        Isim = c.String(nullable: false, maxLength: 50),
                        KategoriID = c.Int(),
                        Tur = c.String(nullable: false, maxLength: 50),
                        Yas = c.Int(nullable: false),
                        Cinsiyet = c.String(nullable: false, maxLength: 5),
                        Renk = c.String(nullable: false, maxLength: 20),
                        Açıklama = c.String(maxLength: 250),
                        ImgURL = c.String(),
                        SahiplendirmeDurumu = c.Boolean(nullable: false),
                        SahipId_KullaniciID = c.Int(),
                    })
                .PrimaryKey(t => t.HayvanId)
                .ForeignKey("dbo.Kategori", t => t.KategoriID)
                .ForeignKey("dbo.Kullanici", t => t.SahipId_KullaniciID)
                .Index(t => t.KategoriID)
                .Index(t => t.SahipId_KullaniciID);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        KullaniciID = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 50),
                        Sifre = c.String(nullable: false, maxLength: 50),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(nullable: false, maxLength: 50),
                        Telefon = c.String(nullable: false, maxLength: 50),
                        Adres = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.KullaniciID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ilanlar", "SahipId_KullaniciID", "dbo.Kullanici");
            DropForeignKey("dbo.Ilanlar", "KategoriID", "dbo.Kategori");
            DropIndex("dbo.Ilanlar", new[] { "SahipId_KullaniciID" });
            DropIndex("dbo.Ilanlar", new[] { "KategoriID" });
            DropTable("dbo.Kullanici");
            DropTable("dbo.Kategori");
            DropTable("dbo.Ilanlar");
            DropTable("dbo.Admin");
        }
    }
}
