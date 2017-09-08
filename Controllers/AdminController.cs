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

        [HttpGet("{last}")]
        public IEnumerable<User> Get(long last)
        {
            DateTime dt = DateTime.Now;
            dt = dt.Subtract(TimeSpan.FromSeconds(60 * 1));
            int count = 4 * 5; //4 screens * 5 lines 
            return App.Auto.Select<User>("from User where Ver>? & Time>? limit 0,?", last, dt, count);
        }
    }
}