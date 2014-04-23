using System;
using System.Web.UI;

using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.StringExtensions;

namespace HideDependentFields.SC.Pipelines.RenderContentEditor
{
    public class InjectScripts
    {
        private const string JavascriptTag = "<script src=\"{0}\"></script>";
        private const string StylesheetLinkTag = "<link href=\"{0}\" rel=\"stylesheet\" />";

        public void Process(PipelineArgs args)
        {
            AddControls(JavascriptTag, "CustomContentEditorJavascript");
            AddControls(StylesheetLinkTag, "CustomContentEditorStylesheets");
        }

        private void AddControls(string resourceTag, string configKey)
        {
            Assert.IsNotNullOrEmpty(configKey, "Content Editor resource config key cannot be null");

            string resources = Sitecore.Configuration.Settings.GetSetting(configKey);

            if (String.IsNullOrEmpty(resources))
                return;

            foreach (var resource in resources.Split('|'))
            {
                Sitecore.Context.Page.Page.Header.Controls.Add((Control)new LiteralControl(resourceTag.FormatWith(resource)));
            }
        }
    }
}
