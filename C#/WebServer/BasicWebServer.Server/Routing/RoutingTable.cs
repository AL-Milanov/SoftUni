using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.ActionResponses;
using BasicWebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        public readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            routes = new();

            routes[Method.GET] = new(StringComparer.InvariantCultureIgnoreCase);
            routes[Method.POST] = new(StringComparer.InvariantCultureIgnoreCase);
            routes[Method.PUT] = new(StringComparer.InvariantCultureIgnoreCase);
            routes[Method.DELETE] = new(StringComparer.InvariantCultureIgnoreCase);

        }


        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            routes[method][path] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
        {
            return Map(Method.GET, path, responseFunction);
        }

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
        {
            return Map(Method.POST, path, responseFunction);
        }

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if (!routes.ContainsKey(requestMethod) ||
                !routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
