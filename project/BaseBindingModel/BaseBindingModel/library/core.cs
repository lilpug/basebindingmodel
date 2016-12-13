using Newtonsoft.Json;
namespace Models.Support
{
    public partial class BaseBindingModel
    {
        // ====================================// 
        //      Main Processing Function       //        
        // ====================================//

        //This function processes the data and outputs the results
        public void Process()
        {
            //Initialises the error categories
            InitErrorCategories();

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
            if (!string.IsNullOrWhiteSpace(successMessage))
            {
                results["success_message"] = successMessage;
            }

            //Adds the errors to the json
            if (totalErrorCount > 0)
            {
                results["success"] = false;
                results["errors"] = JsonConvert.SerializeObject(errors);
            }
            else
            {
                results["success"] = true;
            }
        }


        // ====================================// 
        //     Main Three Override Functions   //        
        // ====================================//

        //These functions are to be overriden at higher inheritance
        //Note: this is done so we do not need to duplicate the core process for all binding models
        protected virtual void InteralProcess()
        {
            //To be overriden
        }
        protected virtual void Validation()
        {
            //To be overriden
        }
        protected virtual void InitErrorCategories()
        {
            //To be overriden
        }
    }
}