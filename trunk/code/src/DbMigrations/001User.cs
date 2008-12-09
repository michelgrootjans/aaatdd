/*
 * Created by: 
 * Created: dinsdag 9 december 2008
 */

using System.Data;
using Migrator.Framework;

namespace DbMigrations
{

    [Migration(001)]
    public class _001User : Migration
    {
        public override void Up()
        {
            Database.AddTable("Users",
                new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Name", DbType.String, ColumnProperty.NotNull),
                new Column("Credit", DbType.Double, ColumnProperty.NotNull, 0.00)
                );
        }

        public override void Down()
        {
            Database.RemoveTable("User");
        }
    }
}