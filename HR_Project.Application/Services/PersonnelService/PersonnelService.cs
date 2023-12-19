using AutoMapper;
using HR_Project.Application.Models.DTOs;
using HR_Project.Application.Models.VMs;
using HR_Project.Domain.Entities.Concrete;
using HR_Project.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HR_Project.Application.Services.PersonnelService
{
	public class PersonnelService : IPersonnelService
	{
		private readonly UserManager<Personnel> _userManager;
		private readonly SignInManager<Personnel> _signInManager;
		private readonly IPersonnelRepository _personnelRepository;
		private readonly IMapper _mapper;
		private readonly IAddressRepository _addressRepository;
		public PersonnelService(UserManager<Personnel> userManager, SignInManager<Personnel> signInManager, IPersonnelRepository personnelRepository, IMapper mapper, IAddressRepository addressRepository)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_personnelRepository = personnelRepository;
			_mapper = mapper;
			_addressRepository = addressRepository;
		}

		public async Task<SignInResult> LoginAsync(LoginDTO loginDTO)
		{
			Personnel user = await _personnelRepository.GetFirstOrDefaultAsync(x => x.UserName == loginDTO.UserName);
			if (user != null)
				return await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
			else
				return SignInResult.Failed;

		}

		public async Task Logout()
		{
			await _signInManager.SignOutAsync();
		}
		public async Task<Personnel> GetPersonnelDetailsAsync(int personnelId)
		{
			var user = await _userManager.FindByIdAsync(personnelId.ToString());
			return user;
		}

		//bu metodun return type ı IdentityResult yerine int yapılabilir!!??
		public async Task<IdentityResult> UpdatePersonnelAsync(UpdatePersonnelDTO personnelDTO)
		{

			var user = await _userManager.FindByIdAsync(personnelDTO.ID.ToString());

			Address address = await _addressRepository.GetFirstOrDefaultAsync(x => x.ID == user.AddressID);
			address.Neighbourhood = personnelDTO.Address.Neighbourhood;
			address.Street = personnelDTO.Address.Street;
			address.City = personnelDTO.Address.City;
			address.Detail = personnelDTO.Address.Detail;
			address.District = personnelDTO.Address.District;

			await _addressRepository.UpdateAsync(address);
			if (user == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
			}

			user.Photo = personnelDTO.Photo;
			user.Phone = personnelDTO.Phone;
			user.Address = address;

			var result = await _userManager.UpdateAsync(user);

			return result;
		}

		public async Task<IdentityResult> UpdatePasswordAsync(UpdatePasswordDTO updatePasswordDTO)
		{

			var user = await _userManager.FindByNameAsync(updatePasswordDTO.UserName);
			if (user == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "User Can'not Find." });
			}
			var passwordValid = await _userManager.CheckPasswordAsync(user, updatePasswordDTO.LastPassword);
			if (!passwordValid)
			{
				return IdentityResult.Failed(new IdentityError { Description = "Last Password is Wrong." });
			}
			if (updatePasswordDTO.NewPassword == updatePasswordDTO.LastPassword)
			{
				return IdentityResult.Failed(new IdentityError { Description = "The New Password Can'not Be the Same as the Last Password." });
			}

			//var lastThreePasswords = GetLastThreePasswords(user);
			//if (lastThreePasswords.Contains(updatePasswordDTO.NewPassword))
			//{
			//    return IdentityResult.Failed(new IdentityError { Description = "New Password Must be Diffirent from Last 3 Password." });
			//}

			var result = await _userManager.ChangePasswordAsync(user, updatePasswordDTO.LastPassword, updatePasswordDTO.NewPassword);
			return result;
		}

		public async Task<IdentityResult> CreateManagerAsync(CreateManagerDTO createManagerDTO, string email)
		{
			Personnel personnel = new Personnel();
			_mapper.Map(createManagerDTO, personnel);
			string pwd = CreatePassword(11);
			personnel.Title = "Manager";
			personnel.CompanyName = createManagerDTO.Company.CompanyName;

			personnel.DateOfStartWorking = DateTime.Now;
			personnel.BirthPlace = "";
			personnel.Department = "";
			personnel.AddressID = 1;
			personnel.Photo = createManagerDTO.Photo;
			personnel.UserName = personnel.Email;
			var result = await _userManager.CreateAsync(personnel, pwd);
			SendEmail(email, pwd, personnel.Name, personnel.Email);
			

			return result;
		}


		public void SendEmail(string email, string pwd, string name, string userName)
		{
			string smtpServer = "smtp.gmail.com";
			int smtpPort = 587;
			string username = "ikprojeyonetici@gmail.com";
			string password = "gkhmniweutqowsqw";

			using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
			{
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(username, password);
				smtpClient.EnableSsl = true;

				MailMessage mail = new MailMessage();
				mail.From = new MailAddress("diyetTakip@gmail.com");
				mail.To.Add(new MailAddress(email));
				mail.Subject = "Email Activion";
				mail.IsBodyHtml = true;


				string body = $@"
    <div style='border: 1px solid #ccc; padding: 10px; width: 300px; margin: 0 auto;'>
        <p>Merhaba {name},</p>
        <p>Aşağıdaki linkten verilen şifre ile giriş yapabilirsin.</p>
        <h1 style='text-align: center; font-size: 24px;'>{pwd}</h1>
        <h1 style='text-align: center; font-size: 24px;'>{userName}</h1>
        <h2 style='text-align: center; font-size: 24px;'>https://hrprojectapp.azurewebsites.net/Login/UpdatePassword</h2>
        <p>Başarılar dileriz!</p>
    </div>";
				mail.Body = body;
				mail.IsBodyHtml = true;

				smtpClient.Send(mail);
			}
		}
		private string CreatePassword(int length)
		{
			const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
			const string specialChars = "!@#$%^&*()_-+=<>?";
			const string digitChars = "0123456789";

			string allChars = uppercaseChars + lowercaseChars + specialChars + digitChars;

			Random random = new Random();
			char[] password = new char[length];

			// Rastgele bir rakam eklemek için kullanılacak bir flag.
			bool hasDigit = false;

			for (int i = 0; i < length; i++)
			{
				char randomChar = allChars[random.Next(allChars.Length)];
				password[i] = randomChar;

				// Eğer rastgele seçilen karakter bir rakam ise, flag'i true yap.
				if (digitChars.Contains(randomChar))
				{
					hasDigit = true;
				}
			}

			// Eğer şifre en az bir rakam içermiyorsa, bir rakam ekleyin.
			if (!hasDigit)
			{
				password[random.Next(length)] = digitChars[random.Next(digitChars.Length)];
			}

			return new string(password);
		}


		public async Task<List<Personnel>> GetAllManagerAsync()
		{
			return await _personnelRepository.GetAllAsync(x => x.IsActive == true && x.Title == "Manager");
		}



		public async Task<Personnel> GetPersonnelAsync(Expression<Func<Personnel, bool>> predicate)
		{
			return await _personnelRepository.GetFirstOrDefaultAsync(predicate);
		}

		public async Task RemovePersonnel(Personnel personnel)
		{
			await _personnelRepository.DeleteAsync(personnel.Id);
		}

		public async Task<List<Personnel>> GetAllPersonnels(Expression<Func<Personnel, bool>> predicate)
		{
			return await _personnelRepository.GetAllAsync(x => x.IsActive == true);
		}

	}
}
