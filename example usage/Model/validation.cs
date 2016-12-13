/*
using Models.Support;
using System.Collections.Generic;

namespace Models.user
{    
    public partial class DeleteAccount : BaseBindingModel
    {
        //This function validates the data
        protected override void Validation()
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                errors["username"].Add("No account has been supplied to delete.");
            }                       
        }

        //This function inits the error categories
        protected override void InitErrorCategories()
        {            
            errors.Add("general", new List<string>());
            errors.Add("username", new List<string>());
        }
    }
}
*/