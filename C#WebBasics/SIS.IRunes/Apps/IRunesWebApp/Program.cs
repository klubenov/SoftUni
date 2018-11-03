﻿using System;
using System.Reflection;
using IRunesWebApp.Controllers;
using IRunesWebApp.Services;
using IRunesWebApp.Services.Contracts;
using Services;
using SIS.Framework;
using SIS.Framework.Routers;
using SIS.Framework.Services;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace IRunesWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            //var handler = new HttpHandler(serverRoutingTable);
            //ConfigureRouting(serverRoutingTable);


            //Server server = new Server(80, handler);

            //server.Run();
            var dependencyContainer = new DependencyContainer();
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();

            var handlingContext = new HttpRouteHandlingContext(new ControllerRouter(dependencyContainer), new ResourceRouter());
            Server server = new Server(80, handlingContext);
            var engine = new MvcEngine();
            engine.Run(server);
        }

        //private static void ConfigureRouting(ServerRoutingTable serverRoutingTable)
        //{
        //    // GET
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] =
        //        request => new RedirectResult("/");
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] =
        //        request => new HomeController().Index(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/login"] =
        //        request => new UsersController().Login(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/register"] =
        //        request => new UsersController().Register(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/all"] =
        //        request => new AlbumsController().All(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/albums/create"] =
        //        request => new AlbumsController().Create(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/logout"] =
        //        request => new UsersController().Logout(request);


        //    // POST
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/login"] =
        //        request => new UsersController().PostLogin(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] =
        //        request => new UsersController().PostRegister(request);
        //    serverRoutingTable.Routes[HttpRequestMethod.Post]["/albums/create"] =
        //        request => new AlbumsController().PostCreate(request);
        //}
    }
}
