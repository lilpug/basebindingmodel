using Models.Support;

namespace Models.Example
{
    public partial class ModelExample : BaseBindingModel
    {   
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
    }
}