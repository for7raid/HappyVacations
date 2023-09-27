using Amazon.Runtime.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YDBTest
{

    public class BuckenEndpointProvider : IEndpointProvider
    {
        public Amazon.Runtime.Endpoints.Endpoint ResolveEndpoint(EndpointParameters parameters)
        {
            return new Amazon.Runtime.Endpoints.Endpoint(parameters["Endpoint"].ToString() + parameters["Bucket"]);
        }
    }
}
