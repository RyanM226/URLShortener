using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace URLShortener.Controllers.API
{
    public class ShortenController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            HttpError err = new HttpError("Not Implemented");
            return Request.CreateResponse(HttpStatusCode.NotImplemented, err);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] string value)
        {
            HttpError err = new HttpError("Not Implemented");
            return Request.CreateResponse(HttpStatusCode.NotImplemented, err);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            HttpError err = new HttpError("Not Implemented");
            return Request.CreateResponse(HttpStatusCode.NotImplemented, err);
        }
    }
}