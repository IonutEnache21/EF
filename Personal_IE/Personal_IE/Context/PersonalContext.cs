namespace Personal_IE.Context
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Conventions;
    using Model;

    public class PersonalContext : DbContext
    {
        
        public PersonalContext() : base("Personal")
        {
            //Database.SetInitializer<PersonalContext>(new CreateDatabaseIfNotExists<PersonalContext>());
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }




        public static Conventions Conventions
        {
            get
            {
                return new Conventions(
                    new MaxLengthConvention(p => p.Name.Contains("Nume"), 50),
                    new MaxLengthConvention(p => p.Name.Contains("Prenume"), 50));
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyCustomConventions(modelBuilder);
        }

        private void ApplyCustomConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
            modelBuilder.Types().Where(t => typeof(Location).IsAssignableFrom(t)).Configure(
                c => c.Property("StreetAddress")
                    .HasMaxLength(250));
            Conventions.Apply(modelBuilder);
        }
    }
}
