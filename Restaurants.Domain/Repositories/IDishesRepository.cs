using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
   // Task<IEnumerable<Restaurant>> GetAllAsync(); 
    //Task<Restaurant?> GetRestaurantById(int id);
    Task<int> Create(Dish entity);
    Task Delete(IEnumerable<Dish> entities);
    //Task SaveChanges();
}