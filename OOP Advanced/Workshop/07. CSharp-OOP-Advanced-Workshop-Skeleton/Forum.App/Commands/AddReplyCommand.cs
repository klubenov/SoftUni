using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName+"Menu");
            if (menu is IIdHoldingMenu iiIdHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                iiIdHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
