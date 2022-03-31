using Authentication.DTOs;
using Authentication.Models;
using Authentication.Models.Login;
using Authentication.Models.Registration;
using Authentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IRepository<MemberDTO> repository;
        private readonly IRepository<Admin> adminrepository;


        public AuthController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
          IConfiguration configuration, IRepository<MemberDTO> repository, IRepository<Admin> adminrepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.repository = repository;
            this.adminrepository = adminrepository;
        }

        [HttpPost("MemberRegistration")]
        public async Task<IActionResult> Register(Member model)
        {

            ApplicationUser appUser = new ApplicationUser
            {

                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                ContactNumber = model.ContactNumber,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                SecretQuestions = model.SecretQuestions,
                Answer = model.Answer

            };


            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Member"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Member" });

            result = await userManager.AddToRoleAsync(appUser, "Member");

            MemberDTO memberdto = new MemberDTO();

            memberdto.ApplicationUser = appUser;
            memberdto.MemberId = model.MemberId;

            repository.Add(memberdto);
            await repository.SaveAsync();

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPost("AdminRegister")]
        public async Task<IActionResult> Register(RegAdmin model)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            //IdentityUser appUser = new IdentityUser
            ApplicationUser appUser = new ApplicationUser
            {
           
                FirstName = model.FirstName,
                LastName = model.LastName,
               DateOfBirth=model.DateOfBirth,
               
               

                Gender = model.Gender,
                PhoneNumber = model.ContactNumber,
              
                PasswordHash = model.Password,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole { Name = "AdminReg" });

            result = await userManager.AddToRoleAsync(appUser, "AdminReg");
            Admin ad = new Admin();

            ad.ApplicationUser = appUser;
          ad.AdminId = model.AdminId;
           adminrepository.Add(ad);
            await adminrepository.SaveAsync();

            if (!result.Succeeded) return BadRequest(result.Errors);

            return Ok();
        }



        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin model)
        {
            ApplicationUser appUser = await userManager.FindByNameAsync(model.UserName);

            if (appUser == null) return BadRequest("Invalid username/password");

            bool isValid = await userManager.CheckPasswordAsync(appUser, model.Password);

            if (!isValid) return BadRequest("Invalid username/password");


            string key = configuration["JwtSettings:Key"];
            string issuer = configuration["JwtSettings:Issuer"];
            string audience = configuration["JwtSettings:Audience"];
            int durationInMinutes = int.Parse(configuration["JwtSettings:DurationInMinutes"]);

            IList<Claim> userClaims = await userManager.GetClaimsAsync(appUser);
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName));

            var roles = await userManager.GetRolesAsync(appUser);
            userClaims.Add(new Claim(ClaimTypes.Role, roles.First()));

            byte[] keyBytes = System.Text.Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(durationInMinutes),
                signingCredentials: signingCredentials,
                claims: userClaims
                );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurityToken);
            var response = new { jwt = token, name = appUser.UserName, role = roles.First() };
            return Ok(response);

        }
    }
}
