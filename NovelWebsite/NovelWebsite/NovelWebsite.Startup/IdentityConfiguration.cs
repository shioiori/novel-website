﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Domain.Providers;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Startup
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders()
                    .AddTokenProvider<EmailConfirmationTokenProvider<User>>(configuration["Environment:EmailConfirmationTokenProvider"]);

            services.Configure<IdentityOptions>(options => {
                // Thiết lập về Password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout - khóa user
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User.
                options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;  // Email là duy nhất

                // Cấu hình đăng nhập.
                options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
                options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

                options.Tokens.EmailConfirmationTokenProvider = configuration["Environment:EmailConfirmationTokenProvider"];
            });

            services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                    opt.TokenLifespan = TimeSpan.FromDays(7));
            return services;
        }
    }
}