using CrudAPIAssessmentCore.Dtos.Users;
using CrudAPIAssessmentCore.Interface;
using CrudAPIAssessmentCore.Modal;
using CrudAPIAssessmentCore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPIAssessmentCore.Services
{

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<string> CreateOrUpdateUser(CreateOrUpdateUser input)
        {
            try
            {
                if (_userRepo.GetAll().Where(s => s.IsDeleted == false).ToList().Any(p => p.Email == input.User.Email) && input.User.Id == 0)
                {
                    return "This email is already exist";
                }
                else
                {
                    var user = new User();
                    if (input.User.Id > 0)
                    {
                        user = await _userRepo.GetAll().Where(u => u.Id == input.User.Id).FirstOrDefaultAsync();
                        user.FullName = input.User.FullName;
                        user.MidleName = input.User.MidleName;
                        user.Email = input.User.Email;
                        user.Birthday = input.User.Birthday;
                        user.Phone = input.User.Phone;
                        user.LocationOfElection = input.User.LocationOfElection;
                        user.Address1 = input.User.Address1;
                        user.Address2 = input.User.Address2;
                        user.OtherNationality = input.User.OtherNationality;
                        user.Country = input.User.Country;
                        user.CountryIso = input.User.CountryIso;
                        user.PassportPath = input.User.PassportPath;
                        user.ProfilePath = input.User.ProfilePath;
                        user.SelfiePath = input.User.SelfiePath;
                        user.UtilityBillPath = input.User.UtilityBillPath;
                        user.FacebookSocialLink = input.User.FacebookSocialLink;
                        user.TweeterSocialLink = input.User.TweeterSocialLink;
                        user.InstaSocialLink = input.User.InstaSocialLink;
                        user.LinkedInSocialLink = input.User.LinkedInSocialLink;
                        user.YoutubeSocialLink = input.User.YoutubeSocialLink;
                        await _userRepo.UpdateAsync(user);
                        return "SuccessFully Updated";
                    }
                    else
                    {
                        user.FullName = input.User.FullName;
                        user.MidleName = input.User.MidleName;
                        user.Email = input.User.Email;
                        user.Phone = input.User.Phone;
                        user.Birthday = input.User.Birthday;
                        user.LocationOfElection = input.User.LocationOfElection;
                        user.Address1 = input.User.Address1;
                        user.Address2 = input.User.Address2;
                        user.OtherNationality = input.User.OtherNationality;
                        user.Country = input.User.Country;
                        user.CountryIso = input.User.CountryIso;
                        user.PassportPath = input.User.PassportPath;
                        user.ProfilePath = input.User.ProfilePath;
                        user.SelfiePath = input.User.SelfiePath;
                        user.UtilityBillPath = input.User.UtilityBillPath;
                        user.FacebookSocialLink = input.User.FacebookSocialLink;
                        user.TweeterSocialLink = input.User.TweeterSocialLink;
                        user.InstaSocialLink = input.User.InstaSocialLink;
                        user.LinkedInSocialLink = input.User.LinkedInSocialLink;
                        user.YoutubeSocialLink = input.User.YoutubeSocialLink;
                        user.CreatedDate = input.User.CreatedDate;
                        user.CreatedBy = input.User.CreatedBy;
                        user.IsDeleted = false;
                        await _userRepo.AddAsync(user);
                        return "SuccessFully Added";
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public async Task<GetUserForEditOutput> GetUserForEdit(int id)
        {
            GetUserForEditOutput input = new GetUserForEditOutput();

            input.User = await _userRepo.GetAll().Where(u => u.Id == id && u.IsDeleted == false).Select(n => new UserEditDto
            {
                Id = n.Id,
                FullName = n.FullName,
                MidleName = n.MidleName,
                Address1 = n.Address1,
                Address2 = n.Address2,
                Birthday = n.Birthday,
                CountryIso = n.CountryIso,
                Country = n.Country,
                CreatedDate = n.CreatedDate,
                Email = n.Email,
                FacebookSocialLink = n.FacebookSocialLink,
                InstaSocialLink = n.InstaSocialLink,
                LinkedInSocialLink = n.LinkedInSocialLink,
                LocationOfElection = n.LocationOfElection,
                OtherNationality = n.OtherNationality,
                PassportPath = n.PassportPath,
                Phone = n.Phone,
                ProfilePath = n.ProfilePath,
                SelfiePath = n.SelfiePath,
                TweeterSocialLink = n.TweeterSocialLink,
                UtilityBillPath = n.UtilityBillPath,
                YoutubeSocialLink = n.YoutubeSocialLink,
            }).FirstOrDefaultAsync();
            return input;
        }

        public async Task<List<UserListDto>> GetUsers()
        {
            return await _userRepo.GetAll().Where(u => u.IsDeleted == false)
                            .Select(n => new UserListDto
                            {
                                Id = n.Id,
                                FullName = n.FullName,
                                MidleName = n.MidleName,
                                Address1 = n.Address1,
                                Address2 = n.Address2,
                                Birthday = n.Birthday,
                                CountryIso = n.CountryIso,
                                Country = n.Country,
                                CreatedDate = n.CreatedDate,
                                Email = n.Email,
                                FacebookSocialLink = n.FacebookSocialLink,
                                InstaSocialLink = n.InstaSocialLink,
                                LinkedInSocialLink = n.LinkedInSocialLink,
                                LocationOfElection = n.LocationOfElection,
                                OtherNationality = n.OtherNationality,
                                PassportPath = n.PassportPath,
                                Phone = n.Phone,
                                ProfilePath = n.ProfilePath,
                                SelfiePath = n.SelfiePath,
                                TweeterSocialLink = n.TweeterSocialLink,
                                UtilityBillPath = n.UtilityBillPath,
                                YoutubeSocialLink = n.YoutubeSocialLink,
                            }).OrderBy(s => s.FullName).ToListAsync();
        }

        public async Task DeleteUser(int Id, string deletedBy)
        {
            try
            {
                var component = await _userRepo.GetAll().Where(u => u.Id == Id).FirstOrDefaultAsync();
                if (component != null)
                {
                    component.IsDeleted = true;
                    component.DeletedBy = deletedBy;
                    await _userRepo.UpdateAsync(component);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
