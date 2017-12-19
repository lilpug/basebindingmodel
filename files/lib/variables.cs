using System.Collections.Generic;
using System.Collections.Specialized;

namespace Models.Support
{
    /// <summary>
    /// This is the BaseBindingModel which can be inherited to make model binding much more easier
    /// </summary>
    public partial class BaseBindingModel
    {
        // ====================================// 
        //          Variables Required         //        
        // ====================================//

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
        /// This variable loops through the errors dictionary and pulls the error count out
        /// </summary>
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

        /// <summary>
        /// The Constructor method which initialises the resources required
        /// </summary>
        public BaseBindingModel()
        {
            Results = new HybridDictionary();
        }
    }
}