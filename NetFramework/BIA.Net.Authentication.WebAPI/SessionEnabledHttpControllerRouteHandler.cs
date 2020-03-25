﻿namespace BIA.Net.Authentication.WebAPI
{
    using System.Web;
    using System.Web.Http.WebHost;
    using System.Web.Routing;

    public class SessionEnabledHttpControllerRouteHandler : HttpControllerRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SessionEnabledControllerHandler(requestContext.RouteData);
        }
    }
}