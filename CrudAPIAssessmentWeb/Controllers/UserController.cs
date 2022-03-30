using CrudAPIAssessmentCore.Dtos.Users;
using CrudAPIAssessmentCore.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CrudAPIAssessment.Controllers
{
    public class UserController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IUserService _userService;
        public UserController(IHostingEnvironment environment, IUserService userService)
        {
            _userService = userService;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }
        public async Task<IActionResult> SignUpForm(int id)
        {
            GetUserForEditOutput model;

            if (id > 0)
            {
                model = await _userService.GetUserForEdit(id);

            }
            else
            {
                model = new GetUserForEditOutput();
                model.User = new UserEditDto();
                model.User.Birthday = DateTime.Now;
            }
            return View(model);
        }
        [HttpPost]
        public async Task<JsonResult> SignUp()
        {
            var PassportPath = Request.Form["PassportPath"];
            var ProfilePath = Request.Form["ProfilePath"];
            var SelfiePath = Request.Form["SelfiePath"];
            var UtilityBillPath = Request.Form["UtilityBillPath"];

            var model = new CreateOrUpdateUser();
            model = JsonConvert.DeserializeObject<CreateOrUpdateUser>(Request.Form["CreateOrUpdateUser"],
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            for (int i = 1; i < 5; i++)
            {
                var httpPosted = Request.Form.Files["ImgUrl" + i];
                if (httpPosted != null)
                {
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    var FileExtension = Path.GetExtension(httpPosted.FileName);
                    var newFileName = myUniqueFileName + FileExtension;
                    var filepath = Path.Combine(_environment.WebRootPath, "UploadImages") + $@"\{newFileName}";
                    if (model.User.PassportPath == null)
                    {
                        model.User.PassportPath = $"/UploadImages/{newFileName}";
                    }
                    else if (model.User.ProfilePath == null)
                    {
                        model.User.ProfilePath = $"/UploadImages/{newFileName}";
                    }
                    else if (model.User.SelfiePath == null)
                    {
                        model.User.SelfiePath = $"/UploadImages/{newFileName}";
                    }
                    else if (model.User.UtilityBillPath == null)
                    {
                        model.User.UtilityBillPath = $"/UploadImages/{newFileName}";
                    }
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        httpPosted.CopyTo(fs);
                        fs.Flush();
                    }

                }
                else
                {
                    if (i == 1)
                    {
                        if (PassportPath != "")
                        {
                            model.User.PassportPath = PassportPath;
                        }
                    }
                    else if (i == 2)
                    {
                        if (ProfilePath != "")
                        {
                            model.User.ProfilePath = ProfilePath;
                        }
                    }
                    else if (i == 3)
                    {
                        if (SelfiePath != "")
                        {
                            model.User.SelfiePath = SelfiePath;
                        }
                    }
                    else if (i == 4)
                    {
                        if (UtilityBillPath != "")
                        {
                            model.User.UtilityBillPath = UtilityBillPath;
                        }
                    }
                }
            }
            model.User.CreatedDate = DateTime.Now;
            var result = await _userService.CreateOrUpdateUser(model);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            try
            {
                await _userService.DeleteUser(Id, "Admin");
                return Json("Successfully deleted");

            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }

        }
    }
}
