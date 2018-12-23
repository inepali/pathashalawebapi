using com.pathshala.Models;
using System.Web.Http;
using System.Web.Mvc;

namespace com.pathshala.Controllers
{
    public class BaseController : Controller
    {

        private PathshalaModelsDataContext _db;

        public PathshalaModelsDataContext DB
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

    }
}
