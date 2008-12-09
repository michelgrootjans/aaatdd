/*
 * Created by: 
 * Created: dinsdag 9 december 2008
 */

using System.Data;
using Migrator.Framework;

namespace DbMigrations
{

    [Migration(002)]
    public class _002Snack : Migration
    {
        public override void Up()
        {
            Database.AddTable("Snack",
                new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("UserId", DbType.Int64, ColumnProperty.ForeignKey),
                new Column("Name", DbType.String, ColumnProperty.NotNull),
                new Column("Price", DbType.Double, ColumnProperty.NotNull, 0.00)
                );
            Database.AddForeignKey("FkUsers", "Snack", "UserId", "Users", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("Snack");
        }
    }
}