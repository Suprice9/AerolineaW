using Infractructure.Data;
using Infractructure.Services;
namespace Infractructure.Services
{
    public class DummyDataServices
    {
        public readonly DataBase _context;

        public DummyDataServices(DataBase context)
        {
            _context = context;
        }

        public async Task DatosDummy(int increment)
        {
            await FakeAirplaneSetup(increment);

            await FakeAirport1(increment);

            await FakeAirport2(increment);

            await FakePassenger(increment);

            await FakeTicket(increment);
        }


        private async Task FakeAirplaneSetup(int incremenent)
        {
            var fakeAirplane = FakeSetup.FAirplaneSetup(_context).Generate(incremenent);
            await _context.AddRangeAsync(fakeAirplane);
            await _context.SaveChangesAsync();

        }

        private async Task FakeAirport1(int incremenent)
        {
            var fakeAirport1= FakeSetup.FAirport1Setup(_context).Generate(incremenent);
            await _context.AddRangeAsync(fakeAirport1);
            await _context.SaveChangesAsync();

        }

        private async Task FakeAirport2(int incremenent)
        {
            var fakeAirport2 = FakeSetup.FAirport2Setup(_context).Generate(incremenent);
            await _context.AddRangeAsync(fakeAirport2);
            await _context.SaveChangesAsync();

        }


        private async Task FakePassenger(int incremenent)
        {
            var fakePassenger = FakeSetup.FPassengerSetup(_context).Generate(incremenent);
            await _context.AddRangeAsync(fakePassenger);
            await _context.SaveChangesAsync();

        }

        private async Task FakeTicket(int incremenent)
        {
            var fakeTicket = FakeSetup.FticketSetup(_context).Generate(incremenent);
            await _context.AddRangeAsync(fakeTicket);
            await _context.SaveChangesAsync();

        }

    }
}
