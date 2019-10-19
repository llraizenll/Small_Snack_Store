using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SnackStoreV3.Models
{
   public  class ResponseTokenDto
    {

        public HttpStatusCode code { get; set; }
        public string userAccessToken { get; set; }

    }
}
