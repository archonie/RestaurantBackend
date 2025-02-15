using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger, 
    IMapper mapper, IRestaurantsRepository repository): IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {Restaurant} with {@UpdatedRestaurant}", request.Id, request);
        var restaurant = await repository.GetRestaurantById(request.Id);
        if (restaurant is null)
            return false;
        mapper.Map(request, restaurant);
        await repository.SaveChanges();
        return true;
    }
}