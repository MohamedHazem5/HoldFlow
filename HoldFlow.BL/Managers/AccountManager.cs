using HoldFlow.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoldFlow.BL.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailManager _emailService;

        public AccountManager(UserManager<User> userManager, SignInManager<User> signInManager, IEmailManager emailManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailManager;
        }

        public async Task<AccountOperationResult> RegisterUser(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email.Substring(0, registerDto.Email.IndexOf("@")),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                DateOfBirth = registerDto.DateOfBirth,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return new AccountOperationResult { Success = false, Errors = result.Errors.Select(e => e.Description) };
            }
/*
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), new { token, email = user.Email });

            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", confirmationLink.ToString());
*/
            await _signInManager.SignInAsync(user, true);

            return new AccountOperationResult { Success = true };
        }

        public async Task<AccountOperationResult> ConfirmEmail(string token, string email)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
            {
                return new AccountOperationResult { Success = false, ErrorMessage = "Token or email is missing." };
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AccountOperationResult { Success = false, ErrorMessage = "User not found." };
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return new AccountOperationResult { Success = true };
            }
            else
            {
                return new AccountOperationResult { Success = false, ErrorMessage = "Email confirmation failed." };
            }
        }

        public async Task<AccountOperationResult> LoginUser(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return new AccountOperationResult { Success = false, ErrorMessage = "User not Found" };
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result)
            {
                return new AccountOperationResult { Success = false, ErrorMessage = "Invalid username or password" };
            }

            return new AccountOperationResult { Success = true };
        }
    }
}

