using Microsoft.EntityFrameworkCore.Migrations;

namespace TraceabilityVisualization.Migrations
{
    public partial class sp1GetKomoraCartsVisualization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                        IF OBJECT_ID('GetKomoraCartsVisualization') IS NOT NULL
                        DROP PROC GetKomoraCartsVisualization
                        GO

                        CREATE PROCEDURE [dbo].[GetKomoraCartsVisualization]
                        AS
                        BEGIN 

                        SELECT ID_Trace, Nr_wozka, Nm, Material, Typ_cewki, Kolor_cewki, TS_KOM1 FROM tblTrace
                        WHERE TS_SUSZ1 IS NOT NULL AND 
                        (TS_KOM1 IS NOT NULL AND TS_PW1 IS NULL OR 
                        TS_PW1 IS NOT NULL AND TS_KOM2 IS NOT NULL AND TS_PW2 IS NULL)
                        AND TS_OUT IS NULL

                        ORDER BY Nr_wozka ASC

                        END";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC GetKomoraCartsVisualization");
        }
    }
}
