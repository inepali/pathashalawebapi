using com.pathshala.Models;
using System.Web.Http;


namespace Controllers.Api
{
    public class BaseApiController : ApiController
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
