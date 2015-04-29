namespace Personal_IE.Conventions
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Reflection;

    public class Conventions
    {
        private List<MaxLengthConvention> conventions;

        public Conventions(params MaxLengthConvention[] conventions)
        {
            this.conventions = new List<MaxLengthConvention>(conventions);
        }

        public void Add(Conventions newConventions)
        {
            conventions.AddRange(newConventions.conventions);
        }

        public void Apply(DbModelBuilder builder)
        {
            foreach (var convention in conventions)
            {
                builder.Properties<string>().Where(convention.Where).Configure(p => p.HasMaxLength(convention.MaxLength));
            }
        }

        public string Apply(PropertyInfo property, string value)
        {
            foreach (var convention in conventions)
            {
                value = convention.Apply(property, value);
            }
            return value;
        }
    }

    public class MaxLengthConvention
    {
        public Func<PropertyInfo, bool> Where { get; set; }
        public int MaxLength { get; set; }

        public MaxLengthConvention(Func<PropertyInfo, bool> where, int maxLength)
        {
            Where = where;
            MaxLength = maxLength;
        }

        public string Apply(PropertyInfo property, string value)
        {
            if (!Where(property) || value.Length < MaxLength)
            {
                return value;
            }
            return value.Substring(0, MaxLength);
        }
    }
}