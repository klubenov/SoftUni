using System;
using System.Linq;
using IRunesWebApp.Models;
using Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace IRunesWebApp.Controllers
{
    public class AlbumsController : BaseController
    {
        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var albums = this.Context.Albums;

            if (albums.Any())
            {
                var listOfAlbums = string.Empty;
                foreach (var album in albums)
                {
                   var albumHtml = $@"<p><a href=""/albums/details/{album.Id}"">{album.Name}</a></p>";
                    listOfAlbums += albumHtml;
                }
                this.ViewBag["albumsList"] = listOfAlbums;
            }
            else
            {
                this.ViewBag["albumsList"] = "There are currently no albums.";
            }

            return this.View();
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            return this.View();
        }

        public IHttpResponse PostCreate(IHttpRequest request)
        {
            var name = request.FormData["name"].ToString();
            var cover = request.FormData["cover"].ToString();

            var album = new Album
            {
                Name = name,
                Cover = cover
            };

            this.Context.Albums.Add(album);

            try
            {
                this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                // TODO: Log error
                return new BadRequestResult(
                    e.Message,
                    HttpResponseStatusCode.InternalServerError);
            }

            var response = new RedirectResult("/albums/all");

            return response;
        }
    }
}
