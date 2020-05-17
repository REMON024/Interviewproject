using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNET.BLL;
using ASPNET.DTO;
using ASPNET.DTO.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _user;
        public UserController(IUserBLL user)
        {
            _user = user;
        }
        [HttpPost("AddUser")]
        public ActionResult AddUser(User user)
        {
            return new JsonResult(_user.AddComments(user));
        }

        [HttpPost("GetPostDetails")]
        public ActionResult GetPostDetails(PostFilterPagination postFilter)
        {
            return new JsonResult(_user.GetUserPostDetails(postFilter));
        }
    }
}