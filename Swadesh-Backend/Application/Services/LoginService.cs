﻿using Application.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class LoginService : ILoginService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginService> _logger;

    public LoginService(UserManager<User> userManager, IConfiguration configuration, ILogger<LoginService> logger)
    {
        _userManager = userManager;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> AuthenticateUserAsync(LoginDto loginDto)
    {
        try
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                _logger.LogWarning("Invalid login request with email: {Email}", loginDto?.Email);
                throw new ArgumentException("Invalid login request.");
            }

            var normalizedEmail = loginDto.Email.Trim().Normalize().ToUpperInvariant();
            _logger.LogInformation("Attempting to find user with normalized email: {Email}", normalizedEmail);

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == normalizedEmail);
            if (user == null)
            {
                _logger.LogWarning("User with normalized email {Email} not found.", normalizedEmail);
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            _logger.LogInformation("User with email {Email} found. Checking password.", loginDto.Email);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                _logger.LogWarning("Invalid password attempt for user with email {Email}.", loginDto.Email);
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            _logger.LogInformation("User with email {Email} authenticated successfully.", loginDto.Email);

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

            authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Argument exception occurred in AuthenticateUserAsync.");
            throw new ArgumentException("Invalid login details provided.");
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError(ex, "Unauthorized access exception occurred in AuthenticateUserAsync.");
            throw new UnauthorizedAccessException("Authentication failed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred in AuthenticateUserAsync.");
            throw new Exception("An error occurred while processing your request.");
        }
    }

}
