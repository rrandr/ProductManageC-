using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LogAPIController : ApiController
    {
        private MyLogContext db2 = new MyLogContext();
        // GET: LogAPI
        public IEnumerable<Log> GetLogAll()
        {
            return db2.Log.ToList();
        }
    }
}