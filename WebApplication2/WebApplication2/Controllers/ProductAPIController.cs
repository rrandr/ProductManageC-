using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductAPIController : ApiController
    {
       
        private myDBContext db = new myDBContext();
        private MyLogContext db2 = new MyLogContext();


        #region Get All Product
        // GET api/EmployeeInfoAPI
        public IEnumerable<Product> GetProductAll()
        {
            return db.Product.ToList();
        }
        #endregion

        #region Get Product Info
        // GET api/EmployeeInfoAPI/5
        public Product GetProductInfo(int id)
        {
            Product employeeinfo = db.Product.Find(id);
            if (employeeinfo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return employeeinfo;
        }
        #endregion

        #region Update Product Info
        // PUT api/EmployeeInfoAPI/5
        public HttpResponseMessage PutProductInfo(int id, Product productinfo)
        {
            if (ModelState.IsValid && id == productinfo.ProdID)
            {
                db.Entry(productinfo).State = EntityState.Modified;
                Log log = new Log();

                log.Message = "User: "+id+" Updated";
                log.Date = DateTime.Now.ToString();
                db2.Log.Add(log);
                try
                {
                    db2.SaveChanges();
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Save Product Info
        // POST api/EmployeeInfoAPI
        public HttpResponseMessage PostProductInfo(Product productinfo)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(productinfo);
                Log log = new Log();

                log.Message = "New User Added!";
                log.Date = DateTime.Now.ToString();

                db2.Log.Add(log);
                db2.SaveChanges();
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productinfo);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = productinfo.ProdID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region Delete Product
        // DELETE api/EmployeeInfoAPI/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            Product employeeinfo = db.Product.Find(id);
            if (employeeinfo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Log log = new Log();

            log.Message = "User: " + id + " Deleted";
            log.Date = DateTime.Now.ToString();
            db2.Log.Add(log);

            db2.SaveChanges();
            db.Product.Remove(employeeinfo);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, employeeinfo);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}