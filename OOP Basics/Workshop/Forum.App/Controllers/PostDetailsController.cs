using System;
using Forum.App.UserInterface;

namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Services;
    using Forum.App.Views;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        private enum Command
        {
            Back, Reply
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Reply:
                    return MenuState.AddReplyToPost;
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
            }

            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            PostViewModel pvm = PostService.GetPostViewModel(this.PostId);
            return new PostDetailsView(pvm,this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }
    }
}
