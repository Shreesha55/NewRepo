using TradeNetProject.Models;

namespace TradeNetProject.Repositories
{
    public interface ITradeOfficerRepository : IRepository<TradeOfficer>
    {
        TradeOfficer GetCurrentOfficer();
    }
}
