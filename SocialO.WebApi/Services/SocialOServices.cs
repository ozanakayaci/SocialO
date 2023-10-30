using Microsoft.AspNetCore.Authentication;
using SocialO.BL.Abstract;
using SocialO.BL.Concrete;
using SocialO.DAL.Repository.Abstract;
using SocialO.DAL.Repository.Concrete;

namespace SocialO.WebApi.Services;

public static class SocialOServices
{
    public static IServiceCollection AddSocialOServices(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IPostManager, PostManager>();

        services.AddScoped<IPostCommentRepository, PostCommentRepository>();
        services.AddScoped<IPostCommentManager, PostCommentManager>();

        services.AddScoped<IPostFavoriteRepository, PostFavoriteRepository>();
        services.AddScoped<IPostFavoriteManager, PostFavoriteManager>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserManager, UserManager>();

        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        services.AddScoped<IUserProfileManager, UserProfileManager>();

        services.AddScoped<IFollowerRelationshipRepository, FollowerRelationshipRepository>();
        services.AddScoped<IFollowerRelationshipManager, FollowerRelationshipManager>();

        services.AddScoped<AuthService>();

        return services;
    }
}