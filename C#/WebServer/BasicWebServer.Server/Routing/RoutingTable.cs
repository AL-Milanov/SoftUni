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
        public readonly Dictionary<Method, Dictionary<string, Response>> routes;

        public RoutingTable()
        {
            routes = new();

            routes[Method.GET] = new();
            routes[Method.POST] = new();
            routes[Method.PUT] = new();
            routes[Method.DELETE] = new();

        }


        public IRoutingTable Map(string url, Method method, Response response)
        {
            if (method == Method.GET)
            {
                return MapGet(url, response);
            }
            else if (method == Method.POST)
            {
                return MapPost(url, response);
            }
            else
            {
                throw new InvalidOperationException($"Method '{method}' is not supported.");
            }
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.GET][url] = response;

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));


            routes[Method.POST][url] = response;

            return this;
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

            return routes[requestMethod][requestUrl];
        }
    }
}
