using System.Linq.Expressions;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities.Artworks;
using Model.Entities.Auctions;

namespace Domain.Repositories.Implementations; 

public class AuctionRepository : ARepository<Auction>, IAuctionRepository {
    
    public AuctionRepository(AuctionDbContext dbContext) : base(dbContext) {
        
    }
    public async Task<List<Auction>> ReadGraphAsync(Expression<Func<Auction, bool>> filter)
        => await _table
            .Include(t => t.AuctionItems)
            .Where(filter)
            .ToListAsync();
            
    public async Task<Auction?> ReadGraphAsync(int id)
        => await _table
            .Include(t => t.AuctionItems)
            .ThenInclude(c=>c.Artwork)
            .SingleOrDefaultAsync(t=>t.Id == id);
}