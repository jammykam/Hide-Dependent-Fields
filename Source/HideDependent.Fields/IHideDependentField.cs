using System.Web.UI;


namespace HideDependentFields.Types
{
    public interface IHideDependentField
    {
        string Source { get; set; }
        string Class { get; set; }
        AttributeCollection Attributes { get; }
    }
}
