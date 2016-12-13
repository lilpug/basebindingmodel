# BaseBindingModel

The BaseBindingModel is a class library that deals with the generic validation and data processing while doing model binding in C# MVC and Aspnet Core.

## Required
This library requires the json.net library http://www.newtonsoft.com/json

## Getting Started
* Download and reference the dll file in compiled folder.
* Download Json.net and reference it in your project.

## General Structure

The BaseBindingModel is made up of 2 variables and 1 main function and 3 overridable functions
```c#
	//This variable is what stores the results to be used after the process() function has been run.
	public JObject results

	//This variable is an internal variable that is used to store the error list categories
	protected Dictionary<string, List<string>> errors
	
	//This is the main trigger function which sets everything off
	public void Process()
	
	//This is where all the main processing should be done
	protected override void InteralProcess()
	
	//This is where all the validation rules should be done
	protected override void Validation()
	
	//This is where the different error categories should be setup
	protected override void InitErrorCategories()
```

##How To Use

To use simply inherit the BaseBindingModel class into your Model Binding class.
```c#
	public class YourModelBindingClass : BaseBindingModel
	{
	}
```

you can then use "InternalProcess", "Validation" and "InitErrorCategories" to process and validate your binding data.
```c#
	public class YourModelBindingClass : BaseBindingModel
	{
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
	
		public string username { get; set; } 
	}
```

Once your model is ready simply call the process function in your controller and then return the results
```c#
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
```

## Copyright and License
Copyright &copy; David Whitehead

This project is licensed under the MIT License.

You do not have to do anything special by using the MIT license and you don't have to notify anyone that your using this license. You are free to use, modify and distribute this software in any normal and commercial usage. If being used for any commercial purposes the latest copyright license file supplied above which is known as "LICENSE" must also be distributed with any compiled code that is being sold that utilises "BaseBindingModel".