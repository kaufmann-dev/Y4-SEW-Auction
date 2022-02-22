using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities.Auctions;

namespace Domain.Repositories.Implementations; 

public class AuctionRepository : ARepository<Auction>, IAuctionRepository {
    
    public AuctionRepository(AuctionDbContext dbContext) : base(dbContext) {
        
    }
    public async Task<List<Auction>> ReadGraphAsync(Expression<Func<Auction, bool>> filter)
        => await _table
            .Include(t => t.Artwork)
            .ThenInclude(m => m.CoolList)
            .Where(filter)
            .ToListAsync();
}