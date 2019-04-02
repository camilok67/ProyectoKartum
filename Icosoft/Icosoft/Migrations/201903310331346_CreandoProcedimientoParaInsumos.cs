namespace Icosoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreandoProcedimientoParaInsumos : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("sp_Insumo_Por_Proveedor", x => new { idSupplier = x.Int() },
                "Selec SupplieName from Supplies where idSupplier = @idSupplier");
        }
        
        public override void Down()
        {
            DropStoredProcedure("sp_Insumo_Por_Proveedor");
        }
    }
}
