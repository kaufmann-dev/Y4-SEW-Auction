using System.Linq.Expressions;
using Model.Entities.Auctions;

namespace Domain.Repositories.Interfaces; 

public interface IAuctionRepository : IRepository<Auction> {

    Task<List<Auction>> ReadGraphAsync(Expression<Func<Auction, bool>> filter);
    Task<Auction> ReadGraphAsync(int id);

}