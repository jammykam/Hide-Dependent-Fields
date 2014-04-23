using System;

using Sitecore.Shell.Applications.ContentEditor;


namespace HideDependentFields.Types
{
    /// <summary>
    /// Custom implementation for DropList with support to hide following siblings in Content Editor
    /// Selected value is stored as GUID
    /// </summary>
    public class HideDependentLookupEx : LookupEx, IHideDependentField
    {
        public HideDependentLookupEx()
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
