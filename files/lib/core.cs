using System.Collections.Generic;

namespace Models.Support
{
    /// <summary>
    /// This is the BaseBindingModel which can be inherited to make model binding much more easier
    /// </summary>
    public partial class BaseBindingModel
    {
        // ====================================// 
        //     Main Processing Functions       //        
        // ====================================//

        /// <summary>
        /// This function processes the data and outputs the results into the results object
        /// </summary>
        public virtual void Process()
        {
            //Fires up the validation
            Validation();                     

            //Gets the total count of errors
            int totalErrorCount = GetErrorCount;

            //If no validation errors occured then continue
            if (totalErrorCount == 0)
            {
                //Runs the internal process *main functionality*
                InteralProcess();
            }

            //Re gets the validation errors to see if any occured in the internal process itself
            totalErrorCount = GetErrorCount;

            //If a success message has been supplied
            if (!string.IsNullOrWhiteSpace(SuccessMessage))
            {
                Results["success_message"] = SuccessMessage;
            }

            //Adds the errors to the json
            if (totalErrorCount > 0)
            {
                Results["success"] = false;
                Results["errors"] = errors;
            }
            else
            {
                Results["success"] = true;
            }
        }

        /// <summary>
        /// This function creates an error list for the name specified if one does not exist and adds the message to the list
        /// </summary>
        /// <param name="errorName"></param>
        /// <param name="errorMessage"></param>
        protected virtual void AddValidationRule(string errorName, string errorMessage)
        {
            //Checks if the error list exists for this particular error name
            if (!errors.ContainsKey(errorName))
            {
                errors.Add(errorName, new List<string>());
            }

            //Adds the new error message to the list
            errors[errorName].Add(errorMessage);
        }

        // ====================================// 
        //     Main Two Override Functions     //        
        // ====================================//

        //These functions are to be overriden at higher inheritance
        //Note: this is done so we do not need to duplicate the core process for all binding models
        /// <summary>
        /// This function is designed to be overriden and used where your main processing is done after validation has been successful
        /// </summary>
        protected virtual void InteralProcess()
        {
            //To be overriden
        }

        /// <summary>
        /// This function is designed to be overriden and used for your validation which is required prior to the internal process running
        /// </summary>
        protected virtual void Validation()
        {
            //To be overriden
        }
    }
}