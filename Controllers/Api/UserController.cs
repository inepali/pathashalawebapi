using com.pathshala.Models;
using Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace com.pathshala.Controllers.Api
{
	public class UserController : BaseApiController
	{
		// GET api/<controller>
		public IEnumerable<AppUser> Get()
		{
			IEnumerable<AppUser> appusers = from au in DB.AppUsers
											select au;

			return appusers;
		}

		// GET api/<controller>/5
		public AppUser Get(int id)
		{
			AppUser appuser = (from au in DB.AppUsers
							   where au.ID == id
							   select au).FirstOrDefault();

			return appuser;
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}