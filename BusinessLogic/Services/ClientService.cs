using System;
using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.Services
{
    public class ClientService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly UserManager<Client> _userManager;
        
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public ClientService(UnitOfWork unitOfWork, IMapper mapper, UserManager<Client> userManager, RoleManager<IdentityRole<int>> roleManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<OperationDetails> Register(RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.UserName);

            if (userExists != null)
                return new OperationDetails(false, "User already exist", "Username");

            var client = new Client()
            {
                Email = registerDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.UserName,
                CompanyName = registerDto.CompanyName,
                Address = registerDto.Address,
                Phone = registerDto.Phone,
                ContactPerson = registerDto.ContactPerson
            };

            var result = await _userManager.CreateAsync(client, registerDto.Password);

            if (!result.Succeeded)
            {
                var errorDescription = String.Join(' ', result.Errors.Select(e => e.Description));

                return new OperationDetails(false, "Incorrect password", "password");
            }

            _userManager.AddToRoleAsync(client, "Client").Wait();

            return new OperationDetails(true, "Registration successful", "");
        }

        public async Task<LoginDetails> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return new LoginDetails(false, "Failed to login", "", DateTime.Now);
            
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new LoginDetails(true, "Login successful", new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);

        }

        public async Task<IList<ClientDto>> GetAllClients()
        {
            var clients = await _unitOfWork.Clients.Get();
            return _mapper.Map<IList<ClientDto>>(clients);
        }

        public async Task AddClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _unitOfWork.Clients.Create(client);
            _unitOfWork.Save();
        }

        public async Task UpdateClient(ClientDto clientDto)
        {
             var client = _mapper.Map<Client>(clientDto);
             await _unitOfWork.Clients.Update(client);
            _unitOfWork.Save();
        }

        public async Task<ClientDto> GetClientById(int id)
        {
            var client = await _unitOfWork.Clients.FindById(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task DeleteClient(int id)
        {
            await _unitOfWork.Clients.Remove(id);
            _unitOfWork.Save();
        }
    }
}
