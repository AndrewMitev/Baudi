namespace Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public sealed class Configuration : DbMigrationsConfiguration<BaudiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BaudiDbContext context)
        {
            if (!context.Cars.Any())
            {
                var bmwOne = new Car
                {
                    Name = "BMW M6 Grand Coupe",
                    HoursePower = 320,
                    FuelConsumption = 17.0f,
                    Kilometers = 60000,
                    Price = 32000m,
                    Brand = CarType.BMW,
                    ConstructionYear = "2010",
                    Image = "http://www.bmw.bg/content/dam/bmw/common/all-models/m-series/m6-gran-coupe/2015/model-card/BMW-M6-Gran-Coupe_ModelCard.png/jcr:content/renditions/cq5dam.resized.img.485.low.time1447941905994.png"
                };

                context.Cars.Add(bmwOne);

                var bmwTwo = new Car
                {
                    Name = "BMW M4 Coupe Hatchback",
                    HoursePower = 220,
                    FuelConsumption = 12.0f,
                    Kilometers = 120000,
                    Price = 38000m,
                    Brand = CarType.BMW,
                    ConstructionYear = "2011",
                    Image = "http://images.newcars.com/images/car-pictures/original/2015-BMW-M4-Coupe-Hatchback-Base-2dr-Coupe-Photo-1.png"
                };

                context.Cars.Add(bmwTwo);

                var bmwThree = new Car
                {
                    Name = "BMW 4 Series Coupe",
                    HoursePower = 280,
                    FuelConsumption = 9.0f,
                    Kilometers = 80000,
                    Price = 23000m,
                    Brand = CarType.BMW,
                    ConstructionYear = "2009",
                    Image = "https://i.ytimg.com/vi/CiTYQ-Zp3AI/maxresdefault.jpg"
                };

                context.Cars.Add(bmwThree);

                var bmwFour = new Car
                {
                    Name = "BMW M4 Convertible",
                    HoursePower = 190,
                    FuelConsumption = 11.0f,
                    Kilometers = 210000,
                    Price = 31250m,
                    Brand = CarType.BMW,
                    ConstructionYear = "2008",
                    Image = "http://i.telegraph.co.uk/multimedia/archive/03021/BMW-M4-front_3021223b.jpg"
                };

                context.Cars.Add(bmwFour);

                var bmwFive = new Car
                {
                    Name = "BMW i8",
                    HoursePower = 420,
                    FuelConsumption = 8.0f,
                    Kilometers = 1000,
                    Price = 120000m,
                    Brand = CarType.BMW,
                    ConstructionYear = "2014",
                    Image = "http://blog-admin.cddev.org/wp-content/uploads/2016/01/BMW-i8-Mirrorless-cameras-PLACEMENT.jpg"
                };

                context.Cars.Add(bmwFive);


                var audiOne = new Car
                {
                    Name = "Audi Rs6",
                    HoursePower = 600,
                    FuelConsumption = 15.0f,
                    Kilometers = 10000,
                    Price = 100000m,
                    Brand = CarType.Audi,
                    ConstructionYear = "2010",
                    Image = "http://images.car.bauercdn.com/upload/29576/images/001audirs602.jpg"
                };

                context.Cars.Add(audiOne);

                var audiTwo = new Car
                {
                    Name = "Audi Q7",
                    HoursePower = 420,
                    FuelConsumption = 18.0f,
                    Kilometers = 123000,
                    Price = 81000m,
                    Brand = CarType.Audi,
                    ConstructionYear = "2007",
                    Image = "http://pictures.topspeed.com/IMG/crop/201512/2015-audi-q7---driven_600x0w.jpg"
                };

                context.Cars.Add(audiTwo);

                var audiThree = new Car
                {
                    Name = "Audi A4",
                    HoursePower = 220,
                    FuelConsumption = 10.0f,
                    Kilometers = 150000,
                    Price = 20000m,
                    Brand = CarType.Audi,
                    ConstructionYear = "2007",
                    Image = "http://www.caranddriver.com/images/15q3/660572/2017-audi-a4-first-drive-review-car-and-driver-photo-662233-s-429x262.jpg"
                };

                context.Cars.Add(audiThree);

                var audiFour = new Car
                {
                    Name = "Audi A8",
                    HoursePower = 420,
                    FuelConsumption = 14.0f,
                    Kilometers = 10000,
                    Price = 100000m,
                    Brand = CarType.Audi,
                    ConstructionYear = "2011",
                    Image = "http://pictures.topspeed.com/IMG/crop/201203/2012-audi-a8-hybrid_600x0w.jpg"
                };

                context.Cars.Add(audiFour);

                var audiFive = new Car
                {
                    Name = "Audi s5",
                    HoursePower = 360,
                    FuelConsumption = 18.0f,
                    Kilometers = 25000,
                    Price = 78500m,
                    Brand = CarType.Audi,
                    ConstructionYear = "2010",
                    Image = "https://i.ytimg.com/vi/XdxCnlFx9Cs/maxresdefault.jpg"
                };

                context.Cars.Add(audiFive);

                context.SaveChanges();
            }
        }
    }
}
