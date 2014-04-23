using System;

using Sitecore.Shell.Applications.ContentEditor;


namespace HideDependentFields.Types
{
    /// <summary>
    /// Custom implementation for DropList with support to hide following siblings in Content Editor
    /// Selected value is stored as text
    /// </summary>
    public class HideDependentValueLookupEx : ValueLookupEx, IHideDependentField
    {
        public HideDependentValueLookupEx()
            : base()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DependentFieldHelper.SetControlProperties(this);
        }
    }
}
