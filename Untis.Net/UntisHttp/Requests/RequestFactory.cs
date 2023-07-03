using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Untis.Net.UntisHttp.Requests;
internal class RequestFactory
{
    private readonly string _id;

    public RequestFactory(string id)
    {
        _id = id;
    }

    public Request CreateRequest(string method) => new Request()
    {
        Id = _id,
        Jsonrpc = "2.0",
        Method = method
    };
}
