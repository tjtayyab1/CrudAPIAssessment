using CrudAPIAssessmentCore.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPIAssessmentCore.Interface
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetUsers();
        Task<string> CreateOrUpdateUser(CreateOrUpdateUser input);
        Task<GetUserForEditOutput> GetUserForEdit(int id);
        Task DeleteUser(int Id, string deletedBy);
    }
}
