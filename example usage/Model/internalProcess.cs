/*
using Models.Support;
using System;

namespace Models.user
{
    public partial class DeleteAccount : BaseBindingModel
    {
        //Example class only!
        internal class UserModel : IDisposable
        {
            public bool DeleteUser(string username)
            {
                return true;
            }
            public void Dispose() { }
        }

        //Main process which runs
        protected override void InteralProcess()
        {
            using (UserModel user = new UserModel())
            {
                if(user.DeleteUser(username))
                {
                    //Adds a success message
                    successMessage = "The account has been successfully deleted.";                    
                }
                else
                {
                    //Adds a generic error as the process failed
                    errors["general"].Add("While trying to delete the account the process has failed, please try again.");
                }
            }
        }
    }
}
*/