using com.pathshala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Controllers.Api
{
    /// <summary>
    /// This represents API of School entity.
    /// </summary>
    public class SchoolController : BaseApiController
    {

        /// <summary>
        /// Looks up all school data.
        /// Operataion:GET,
        /// Resource Locator : api/School
        /// </summary>
        
        public IEnumerable<School> Get()
        {
            var schools = from s in DB.Schools
                          select s;

            return schools;
        }

        // GET: api/School/5

        /// <summary>
        /// Looks up all school data.
        /// Operataion:GET,
        /// Resource Locator : api/School/{id}
        /// </summary>
        /// <param name="id">The ID of the data.</param>

        public School GetById(int id)
        {
            var school = (from s in DB.Schools
                          where s.ID == id
                          select s).FirstOrDefault();

            return school;
        }

        // POST: api/School
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/School/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/School/5
        public void Delete(int id)
        {
        }
    }
}
