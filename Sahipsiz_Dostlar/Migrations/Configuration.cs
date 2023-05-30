namespace Sahipsiz_Dostlar.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sahipsiz_Dostlar.Entity.Context.Sahipsiz_DostlarDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Sahipsiz_Dostlar.Entity.Context.Sahipsiz_DostlarDB";
        }

        protected override void Seed(Sahipsiz_Dostlar.Entity.Context.Sahipsiz_DostlarDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
