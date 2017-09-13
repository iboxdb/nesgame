using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Game.Controllers
{
    using Game.Models;

    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        [HttpGet("Ver")]
        public long Ver()
        {
            return App.Auto.NewId(byte.MaxValue, 0);
        }

        [HttpGet("{last}")]
        public IEnumerable<User> Get(long last)
        {
            if (last == 0)
            {
                DateTime dt = DateTime.Now;
                dt = dt.Subtract(TimeSpan.FromSeconds(60 * 1));
                return App.Auto.Select<User>("from User where Ver>? limit 0,1000", last)
                           .Where((u) => u.Time > dt);
            }
            else
            {
                return App.Auto.Select<User>("from User where Ver>?", last);
            }
        }
    }
}
