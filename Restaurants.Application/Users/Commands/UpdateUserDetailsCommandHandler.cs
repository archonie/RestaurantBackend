using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands;

public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger, 
    IUserContext userContext, 
    IUserStore<User> userStore): IRequestHandler<UpdateUserDetailsCommand>
{
    
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Updating user: {UserId}, with {@Request}", user!.UserId, request);
        var dbUser = await userStore.FindByIdAsync(user!.UserId, cancellationToken);
        if (dbUser == null)
        {
             throw new NotFoundException(nameof(user), user!.UserId);
        }
        dbUser.Nationality = request.Nationality;
        dbUser.DateOfBirth = request.DateOfBirth;
        
        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}