using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace Models.Support
{
    public partial class BaseBindingModel
    {
        // ====================================// 
        //          Variables Required         //        
        // ====================================//

        //The result output
        public JObject results = new JObject();

        protected string successMessage { get; set; }
        
        //Stores the validation messages for each category
        protected Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        //This variable loops through the errors dictionary and pulls the error count out
        protected int GetErrorCount
        {
            get
            {
                int errorCounter = 0;
                foreach (string key in errors.Keys)
                {
                    errorCounter += errors[key].Count;
                }                                
                return errorCounter;
            }
        }
    }
}