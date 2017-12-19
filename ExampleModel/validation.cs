using Models.Support;
namespace Models.Example
{    
    public partial class ModelExample : BaseBindingModel
    {   
        protected override void Validation()
        {
            if (string.IsNullOrWhiteSpace("exampleFieldValueSuppliedMaybe?"))
            {
                AddValidationRule("fieldName", "Validation failure message for the field ...");
            }                       
        }
    }
}
