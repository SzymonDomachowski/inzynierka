using System.Web.Mvc;
using NotificationBox.Domain.Entities;
using NotificationBox.Domain.Abstract;
using NotificationBox.WebUI.Models;
namespace NotificationBox.WebUI.Controllers
{
    public class InstagramController : Controller
    {
        private IUserRepository repository;

        public InstagramController(IUserRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult InstagramAuthorization()
        {
            RequestInstagramToken requestToken = new RequestInstagramToken();

            InstagramApp.Code = requestToken.GetAuthorizationCode(Request.Url.AbsoluteUri); ;

            dynamic data = requestToken.ReturnInstagramToken();

            repository.AddUser(data);

            return View();

        }

        public ActionResult AuthorizeInstagramUser()
        {
            return Redirect($"https://api.instagram.com/oauth/authorize/?client_id={InstagramApp.ClientId}&redirect_uri={InstagramApp.RedirectUri}&response_type=code");
        }
    }
}