using com.pathshala.Models;
using com.pathshala.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;


namespace com.pathshala.Utils
{
    public static class Utility
    {
        private static PathshalaModelsDataContext _db;

        public static PathshalaModelsDataContext DB
        {
            get
            {
                if (_db != null)
                    return _db;
                else
                {
                    _db = new PathshalaModelsDataContext();
                }
                return _db;
            }
        }


        public static string formatDate(DateTime? d)
        {
            String formattedDate = "";
            if (d != null)
            {
                formattedDate = d.Value.ToShortDateString();
            }

            return formattedDate;
        }


        public static IEnumerable<NameValuePairModel> getLookupByName(String name)
        {
            return from lk in DB.Lookups
                   where lk.Name.Equals(name)
                   select new NameValuePairModel
                   {
                       Name = lk.Display,
                       Value = lk.ID
                   };
        }



        public static IEnumerable<NameValuePairModel> getTeachersNameValue()
        {
            return from t in DB.Teachers
                   select new NameValuePairModel
                   {
                       Name = t.Person.FirstName + " " + t.Person.LastName,
                       Value = t.ID
                   };
        }

        public static IEnumerable<NameValuePairModel> getSchoolsNameValue()
        {
            return from s in DB.Schools
                   select new NameValuePairModel
                   {
                       Name = s.Name,
                       Value = s.ID
                   };
        }


        public static IEnumerable<NameValuePairModel> getGrades()
        {
            IEnumerable<NameValuePairModel> grades =  from g in DB.Grades
                   select new NameValuePairModel
                   {
                       Name = getNameFromGrade(g),
                       Value = g.ID
                   };

            return grades;
        }

        private static string getNameFromGrade(Grade g)
        {
            return g.School.Name.ToString() + " - " + g.Lookup.Display.ToString() + " - " + g.Teacher.Person.DisplayFullName.ToString();;
        }
    }
}