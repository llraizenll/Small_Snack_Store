using SnackStoreV3.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SnackStoreV3.Dto
{
    public class ResponseLogsDto
    {
        public HttpStatusCode Code { get; set; }

        public IEnumerable<LogChangePricesModel> Data { get; set; }
    }
}
