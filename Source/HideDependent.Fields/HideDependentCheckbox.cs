using System;

using Sitecore.Shell.Applications.ContentEditor;


namespace HideDependentFields.Types
{
    /// <summary>
    /// Custom implementation for Checkbox with support to hide following siblings in Content Editor
    /// </summary>
    public class HideDependentCheckbox : Checkbox, IHideDependentField
    {
        public HideDependentCheckbox()
            : base()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DependentFieldHelper.SetControlProperties(this);
        }

        public string Source { get; set; }
    }
}
