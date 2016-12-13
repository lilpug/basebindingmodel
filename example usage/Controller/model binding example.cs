/*
using Models.user;
using Newtonsoft.Json;

namespace Template.Controllers
{
    //Both MVC 4+ or aspnet core example
    //Note: this is why we do not define the mvc version in the using libraries above as its a generic example!
    public partial class ExampleController : Controller
    {  
        public JsonResult UserDelete(DeleteAccount deleteAccount)
        {
            //Runs the process
            deleteAccount.Process();

            //Returns the json results of the action
            return Json(JsonConvert.SerializeObject(deleteAccount.results));
        }
    }
}
*/