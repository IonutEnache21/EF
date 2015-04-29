namespace Personal_IE.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal_IE.Context.PersonalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Personal_IE.Context.PersonalContext context)
        {

            SeedLocation(context);
        }

        private void SeedLocation(Context.PersonalContext context)
        {
            var locationList = new List<Location>
                {
                    new Location
                    {
                        City = "Bucuresti",
                        PostalCode = "601016",
                        StateProvince = "Bucuresti",
                        StreetAddress = "Nr.21-Bl.A-Ap.13"
                    },
                    new Location
                    {
                        City = "Craiova",
                        PostalCode = "401046",
                        StateProvince = "Dolj",
                        StreetAddress = "Nr.22-Bl.C-Ap.12"
                    }
                };

            foreach (var item in locationList)
                context.Locations.AddOrUpdate(p => p.City, item);

            context.SaveChanges();
        }
    }
}
