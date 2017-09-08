using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using iBoxDB.LocalServer;

namespace Game.Controllers
{
    using Game.Models;

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpGet()]
        public User Get()
        {
            User u = new User();
            u.ID = App.Auto.NewId();
            u.GameName = App.Roms[u.ID % App.Roms.Length];
            App.Auto.Insert("User", u);
            return u;
        }

        [HttpPut("{id}")]
        public string Put(long id, [FromBody]string value)
        {
            using (var box = App.Auto.Cube())
            {
                User u = box["User", id].Select<User>();
                u.ImageURL = value;
                u.Time = DateTime.Now;
                box["User"].Update(u);
                CommitResult cr = box.Commit();
                return cr.ToString();
            }
        }


    }
}
