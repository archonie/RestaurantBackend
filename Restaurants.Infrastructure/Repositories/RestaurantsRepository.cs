using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantDbContext dbContext)
    : IRestaurantsRepository
{
    
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }
    
    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(x => x.Id == id);
        return restaurants;
    }

    public async Task<int> Create(Restaurant entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Restaurant entity)
    {
        dbContext.Restaurants.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task SaveChanges()
    {
        await dbContext.SaveChangesAsync();
    }
}