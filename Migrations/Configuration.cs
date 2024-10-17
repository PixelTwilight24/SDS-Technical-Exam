namespace SDS_Technical_Exam.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.ApplicationDBContext context)
        {
            // Seeding RecyclableType Data
            context.RecyclableType.AddOrUpdate(
                rt => rt.Type, // This ensures no duplicates based on the 'Type' property
                new Models.RecyclableType { Type = "Plastic", Rate = 1.5, MinKg = 0.5, MaxKg = 10 },
                new Models.RecyclableType { Type = "Paper", Rate = 0.75, MinKg = 1, MaxKg = 20 },
                new Models.RecyclableType { Type = "Metal", Rate = 3, MinKg = 0.2, MaxKg = 15 }
            );

            // Save changes after seeding RecyclableTypes
            context.SaveChanges();

            // Seeding RecyclableItem Data (Using existing RecyclableTypes)
            var plasticType = context.RecyclableType.FirstOrDefault(rt => rt.Type == "Plastic");
            var paperType = context.RecyclableType.FirstOrDefault(rt => rt.Type == "Paper");

            context.RecyclableItem.AddOrUpdate(
                new Models.RecyclableItem
                {
                    ItemDescription = "Plastic Bottle",
                    Weight = 2,
                    ComputedRate = plasticType.Rate * 2,
                    RecyclableTypeId = plasticType.Id
                },
                new Models.RecyclableItem
                {
                    ItemDescription = "Newspaper Bundle",
                    Weight = 5,
                    ComputedRate = paperType.Rate * 5,
                    RecyclableTypeId = paperType.Id
                }
            );

            // Save the changes after seeding RecyclableItems
            context.SaveChanges();

            base.Seed(context); // Call the base Seed method
        }

    }
}
