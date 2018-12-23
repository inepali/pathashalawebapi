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
    public class PersonController : BaseApiController
    {
        // GET: api/Person
        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> persons = from p in DB.Persons
                                            select p;

            return persons;
        }

        // GET: api/Person
        public Person Get(int id)
        {
            Person person = (from p in DB.Persons
                            where p.ID == id
                            select p).SingleOrDefault();

            return person;
        }

        // GET: api/Person/GetPersonAndStudet
        public Person GetPersonAndStudet(int id)
        {
            Person person = (from p in DB.Persons
                             where p.ID == id
                             select p).SingleOrDefault();

            return person;
        }



        // POST: api/Person
        [HttpPost]
        [AcceptVerbs("POST")]
        public void Post(Person person)
        {
            DB.Persons.InsertOnSubmit(person);
        }

        // PUT: api/Person/5
       
        [HttpPost]
        [AcceptVerbs("PUT")]
        public void Put(int id, Person personObject)
        {
            Person person = (from p in DB.Persons
                             where p.ID == id
                             select p).SingleOrDefault();

            person = Slapper.AutoMapper.MapDynamic<Person>(personObject);

            DB.SubmitChanges();

        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
            Person person = (from p in DB.Persons
                             where p.ID == id
                             select p).SingleOrDefault();

            DB.Persons.DeleteOnSubmit(person);

        }
    }
}
