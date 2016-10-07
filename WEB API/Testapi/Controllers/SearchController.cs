using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testapi.Models;
using Testapi.Service_Layer;
using System.Threading;

namespace Testapi.Controllers
{
    public class SearchController : ApiController
    {
        public string Get_progress(string em)
        {

            return Search.Progress_reporter(em);
        }



        public void Post_search([FromBody] QuerryParameters a)
        {
            UsersQueueMember.Entry(a);
        }

    }
}
