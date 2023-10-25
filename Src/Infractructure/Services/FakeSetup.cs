using Domain.Modelo;
using Bogus;
using Infractructure.Data;

namespace Infractructure.Services
{
    public class FakeSetup
    {
        public static Faker<Airplane> FAirplaneSetup(DataBase db)
        {
            Faker<Airplane> FakeAirplane;
            Randomizer.Seed = new Random(DateTime.Now.Millisecond);

            FakeAirplane = new Faker<Airplane>()
                .RuleFor(a => a.Status, a => a.PickRandom("En vuelo", "Ya aterrizo"))
                .RuleFor(a=>a.AmountPassenger,a=>a.Random.Int(20,50))
                .RuleFor(a=>a.Maxweight,a=>a.Random.Int(300,800))
                .RuleFor(a=>a.Company,a=>a.Company.CompanyName());

            return FakeAirplane;
        }

        public static Faker<Airport1> FAirport1Setup(DataBase db)
        {
            Faker<Airport1> FakeAiport1;
            Randomizer.Seed = new Random(DateTime.Now.Millisecond);

            FakeAiport1 = new Faker<Airport1>()
               .RuleFor(a => a.AirportName, a => a.Company.CompanyName())
               .RuleFor(a => a.Country, a => a.Address.Country())
               .RuleFor(a => a.AirplaneLimit, a => a.Random.Number(4, 15))
               .RuleFor(a => a.AmountAirplane, a => a.Random.Number(4, 15));

            return FakeAiport1;
        }


        public static Faker<Airport2> FAirport2Setup(DataBase db)
        {
            Faker<Airport2> FakeAiport2;
            Randomizer.Seed = new Random(DateTime.Now.Millisecond);

            FakeAiport2 = new Faker<Airport2>()
               .RuleFor(a => a.AirportName, a => a.Company.CompanyName())
               .RuleFor(a => a.Country, a => a.Address.Country())
               .RuleFor(a => a.AirplaneLimit, a => a.Random.Number(4, 15))
               .RuleFor(a => a.AmountAirplane, a => a.Random.Number(4, 15));

            return FakeAiport2;
        }


        public static Faker<Passenger> FPassengerSetup(DataBase db)
        {
            Faker<Passenger> FakerPassenger;
            Randomizer.Seed = new Random(DateTime.Now.Millisecond);

            FakerPassenger = new Faker<Passenger>()
                .RuleFor(a => a.Name, a => a.Person.FullName)
                .RuleFor(a=>a.Weigth, a=>a.Random.Number(110,350))
                .RuleFor(a=>a.Country,a=>a.Address.Country())
                .RuleFor(a=>a.Phone,a=>a.Phone.PhoneNumberFormat())
                .RuleFor(a=>a.Passport,a=>a.Random.Number(000000000,999999999));

            return FakerPassenger;
              
        }
        public static Faker<Ticket> FticketSetup(DataBase db)
        {
            Faker<Ticket> FakerTicket;

            Randomizer.Seed = new Random(DateTime.Now.Millisecond);

            FakerTicket = new Faker<Ticket>()
                .RuleFor(a => a.PassengerId, a => a.PickRandom(db.Passenger.ToList()).Id)
                .RuleFor(a=>a.AirplaneId,a=>a.PickRandom(db.Airplane.ToList()).Id)
                .RuleFor(a=>a.AirportArrivalId,a=>a.PickRandom(db.Airport1.ToList()).Id)
                .RuleFor(a=>a.AirportDepartureId,a=>a.PickRandom(db.Airport2.ToList()).Id)
                .RuleFor(a=>a.ArrivalTime,a=>a.Date.Soon())
                .RuleFor(a=>a.DepartureTime,a=>a.Date.Recent());

            return FakerTicket;
    
         }
    }

}
