namespace Icosoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemaksField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        idPublication = c.Int(nullable: false, identity: true),
                        PublicationName = c.Int(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PublicationDate = c.DateTime(nullable: false),
                        State = c.String(),
                        Height = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Depth = c.Double(nullable: false),
                        MediMeasurementsPublications_idMediMeasurementsPublication = c.Int(),
                        PublicationImages_idPublicationImage = c.Int(),
                        TypePublications_idTypePublication = c.Int(),
                    })
                .PrimaryKey(t => t.idPublication)
                .ForeignKey("dbo.MediMeasurementsPublications", t => t.MediMeasurementsPublications_idMediMeasurementsPublication)
                .ForeignKey("dbo.PublicationImages", t => t.PublicationImages_idPublicationImage)
                .ForeignKey("dbo.TypePublications", t => t.TypePublications_idTypePublication)
                .Index(t => t.MediMeasurementsPublications_idMediMeasurementsPublication)
                .Index(t => t.PublicationImages_idPublicationImage)
                .Index(t => t.TypePublications_idTypePublication);
            
            CreateTable(
                "dbo.MediMeasurementsPublications",
                c => new
                    {
                        idMediMeasurementsPublication = c.Int(nullable: false, identity: true),
                        idPublication = c.Int(nullable: false),
                        idMeasure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMediMeasurementsPublication);
            
            CreateTable(
                "dbo.Measures",
                c => new
                    {
                        idMeasure = c.Int(nullable: false, identity: true),
                        MeasureHeight = c.String(),
                        MeasureWidth = c.String(),
                        DepthMeasurement = c.String(),
                        Description = c.String(),
                        MediMeasurementsPublications_idMediMeasurementsPublication = c.Int(),
                    })
                .PrimaryKey(t => t.idMeasure)
                .ForeignKey("dbo.MediMeasurementsPublications", t => t.MediMeasurementsPublications_idMediMeasurementsPublication)
                .Index(t => t.MediMeasurementsPublications_idMediMeasurementsPublication);
            
            CreateTable(
                "dbo.PublicationImages",
                c => new
                    {
                        idPublicationImage = c.Int(nullable: false, identity: true),
                        idImage = c.Int(nullable: false),
                        idPublication = c.Int(nullable: false),
                        PublicationImage_idPublicationImage = c.Int(),
                    })
                .PrimaryKey(t => t.idPublicationImage)
                .ForeignKey("dbo.PublicationImages", t => t.PublicationImage_idPublicationImage)
                .Index(t => t.PublicationImage_idPublicationImage);
            
            CreateTable(
                "dbo.TypePublications",
                c => new
                    {
                        idTypePublication = c.Int(nullable: false, identity: true),
                        TypePublications = c.String(),
                    })
                .PrimaryKey(t => t.idTypePublication);
            
            CreateTable(
                "dbo.Quotations",
                c => new
                    {
                        idQuotation = c.Int(nullable: false, identity: true),
                        DateCompleted = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        State = c.String(),
                        TypeQuotation = c.String(),
                        incidentals = c.Double(nullable: false),
                        Transport = c.Double(nullable: false),
                        TotalLabor = c.Double(nullable: false),
                        CustomerValue = c.Double(nullable: false),
                        TotalProduction = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idQuotation);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        idDetail = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Depth = c.Double(nullable: false),
                        MeasureHeight = c.String(),
                        MeasureWidth = c.String(),
                        DepthMeasurement = c.String(),
                        DescriptionAdmin = c.String(),
                        DescriptionUser = c.String(),
                        Quotation_idQuotation = c.Int(),
                    })
                .PrimaryKey(t => t.idDetail)
                .ForeignKey("dbo.Quotations", t => t.Quotation_idQuotation)
                .Index(t => t.Quotation_idQuotation);
            
            CreateTable(
                "dbo.DetailImageQuotations",
                c => new
                    {
                        idDetailImageQuotation = c.Int(nullable: false, identity: true),
                        idImagenQuotation = c.Int(nullable: false),
                        idDetail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDetailImageQuotation)
                .ForeignKey("dbo.Details", t => t.idDetail, cascadeDelete: true)
                .ForeignKey("dbo.ImagenQuotations", t => t.idImagenQuotation, cascadeDelete: true)
                .Index(t => t.idImagenQuotation)
                .Index(t => t.idDetail);
            
            CreateTable(
                "dbo.ImagenQuotations",
                c => new
                    {
                        idImagenQuotation = c.Int(nullable: false, identity: true),
                        ImagenQuotations = c.String(),
                    })
                .PrimaryKey(t => t.idImagenQuotation);
            
            CreateTable(
                "dbo.SupplieQuotations",
                c => new
                    {
                        idSupplieQuotation = c.Int(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        UnitValue = c.Double(nullable: false),
                        TotalValue = c.Double(nullable: false),
                        TypeMeasure = c.String(),
                        idSupplie = c.Int(nullable: false),
                        idDetail = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSupplieQuotation)
                .ForeignKey("dbo.Details", t => t.idDetail, cascadeDelete: true)
                .ForeignKey("dbo.Supplies", t => t.idSupplie, cascadeDelete: true)
                .Index(t => t.idSupplie)
                .Index(t => t.idDetail);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        idSupplie = c.Int(nullable: false, identity: true),
                        SupplieName = c.String(),
                        idSuplier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idSupplie)
                .ForeignKey("dbo.Suppliers", t => t.idSuplier, cascadeDelete: true)
                .Index(t => t.idSuplier);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        idSuplier = c.Int(nullable: false, identity: true),
                        SuplierName = c.String(),
                    })
                .PrimaryKey(t => t.idSuplier);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        IDUserType = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.IDUserType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "Quotation_idQuotation", "dbo.Quotations");
            DropForeignKey("dbo.Supplies", "idSuplier", "dbo.Suppliers");
            DropForeignKey("dbo.SupplieQuotations", "idSupplie", "dbo.Supplies");
            DropForeignKey("dbo.SupplieQuotations", "idDetail", "dbo.Details");
            DropForeignKey("dbo.DetailImageQuotations", "idImagenQuotation", "dbo.ImagenQuotations");
            DropForeignKey("dbo.DetailImageQuotations", "idDetail", "dbo.Details");
            DropForeignKey("dbo.Publications", "TypePublications_idTypePublication", "dbo.TypePublications");
            DropForeignKey("dbo.Publications", "PublicationImages_idPublicationImage", "dbo.PublicationImages");
            DropForeignKey("dbo.PublicationImages", "PublicationImage_idPublicationImage", "dbo.PublicationImages");
            DropForeignKey("dbo.Publications", "MediMeasurementsPublications_idMediMeasurementsPublication", "dbo.MediMeasurementsPublications");
            DropForeignKey("dbo.Measures", "MediMeasurementsPublications_idMediMeasurementsPublication", "dbo.MediMeasurementsPublications");
            DropIndex("dbo.Supplies", new[] { "idSuplier" });
            DropIndex("dbo.SupplieQuotations", new[] { "idDetail" });
            DropIndex("dbo.SupplieQuotations", new[] { "idSupplie" });
            DropIndex("dbo.DetailImageQuotations", new[] { "idDetail" });
            DropIndex("dbo.DetailImageQuotations", new[] { "idImagenQuotation" });
            DropIndex("dbo.Details", new[] { "Quotation_idQuotation" });
            DropIndex("dbo.PublicationImages", new[] { "PublicationImage_idPublicationImage" });
            DropIndex("dbo.Measures", new[] { "MediMeasurementsPublications_idMediMeasurementsPublication" });
            DropIndex("dbo.Publications", new[] { "TypePublications_idTypePublication" });
            DropIndex("dbo.Publications", new[] { "PublicationImages_idPublicationImage" });
            DropIndex("dbo.Publications", new[] { "MediMeasurementsPublications_idMediMeasurementsPublication" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Supplies");
            DropTable("dbo.SupplieQuotations");
            DropTable("dbo.ImagenQuotations");
            DropTable("dbo.DetailImageQuotations");
            DropTable("dbo.Details");
            DropTable("dbo.Quotations");
            DropTable("dbo.TypePublications");
            DropTable("dbo.PublicationImages");
            DropTable("dbo.Measures");
            DropTable("dbo.MediMeasurementsPublications");
            DropTable("dbo.Publications");
        }
    }
}
