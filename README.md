# BaseBindingModel

[![The MIT License](https://img.shields.io/badge/license-MIT-orange.svg?style=flat-square&maxAge=3600)](https://github.com/lilpug/basebindingmodel/raw/master/LICENSE)
[![GitHub](https://img.shields.io/github/release/lilpug/modframe.svg?style=flat-square&maxAge=3600)](https://github.com/lilpug/basebindingmodel/releases)
[![NuGet](https://img.shields.io/nuget/v/BaseBindingModel.svg?maxAge=3600)](https://www.nuget.org/packages/BaseBindingModel/)

BaseBindingModel is a library that deals with the generic validation and data processing while doing model binding in C#.NET MVC and ASP.NET Core.

## Getting Started
* Download BaseBindingModel from NuGet or reference the DLL file in compiled folder.

## General Structure

The BaseBindingModel is made up of 3 variables, 1 processing function, 1 validation function and 2 overridable functions
```c#
	/// <summary>
        /// Stores all the results from the process
        /// </summary>
        public HybridDictionary Results { get; set; }

        /// <summary>
        /// Stores a success message if there is one to be outputted
        /// </summary>
        protected string SuccessMessage { get; set; }

        /// <summary>
        /// Stores the validation messages for each category
        /// </summary>
        protected Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
	
	/// <summary>
        /// This function processes the data and outputs the results into the results object
        /// </summary>
        public virtual void Process()
	
	/// <summary>
        /// This function creates an error list for the name specified if one does not exist and adds the message to the list
        /// </summary>
        /// <param name="errorName"></param>
        /// <param name="errorMessage"></param>
        protected virtual void AddValidationRule(string errorName, string errorMessage)
	
	/// <summary>
        /// This function is designed to be overriden and used where your main processing is done after validation has been successful
        /// </summary>
        protected virtual void InteralProcess()
	
	/// <summary>
        /// This function is designed to be overriden and used for your validation which is required prior to the internal process running
        /// </summary>
        protected virtual void Validation()
```

## How To Use

To use simply inherit the BaseBindingModel class into your Model Binding class.
```c#
	public class YourModelBindingClass : BaseBindingModel
	{
	}
```

you can then use "InternalProcess", "Validation" and "AddValidationRule" to process and validate your binding data.
```c#
	public class ExampleModel : BaseBindingModel
	{
		//Any data binding variables i.e.
		public string Name { get; set; }
		public int? Age { get; set; }
	
		//Main process which runs
		protected override void InteralProcess()
		{
		    if(true)
		    {
				SuccessMessage = "The process has been successfully.";
		    }
		    else
		    {
				AddValidationRule("processFailure", "this has failed");
		    }
		}
	
		protected override void Validation()
		{
		    if (string.IsNullOrWhiteSpace("exampleFieldValueSuppliedMaybe?"))
		    {
				AddValidationRule("fieldName", "Validation failure message for the field ...");
		    }                       
		}    
	}
```

Once your model is ready simply call the process function in your controller and then return the results
```c#
	public partial class ExampleController : Controller
    {  
        public IActionResult ExampleAPI(ExampleModel model)
        {
            //Runs the process
            model.Process();

            //Returns the json results of the action
			var content = new ContentResult
			{
				Content = JsonConvert.SerializeObject(deleteAccount.results, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore}),
				ContentType = "application/json"
			};
            return content;
        }
    }
```

## Copyright and License
Copyright &copy; David Whitehead

This project is licensed under the MIT License.

You do not have to do anything special by using the MIT license and you don't have to notify anyone that your using this license. You are free to use, modify and distribute this software in any normal and commercial usage. If being used for any commercial purposes the latest copyright license file supplied above which is known as "LICENSE" must also be distributed with any compiled code that is being sold that utilises "BaseBindingModel".