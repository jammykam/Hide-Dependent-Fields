using System;

using Sitecore;


namespace HideDependentFields.Types
{
    public static class DependentFieldHelper
    {
        public static void SetControlProperties(IHideDependentField control)
        {
            if (String.IsNullOrEmpty(control.Source))
                return;

            if (!String.IsNullOrEmpty(control.Source.HideByDefault()) || !String.IsNullOrEmpty(control.Source.ValuesToHide()))
            {
                control.Attributes["onchange"] = "HideDependentFields(this, true)";
                control.Attributes["data-hide-default"] = control.Source.HideByDefault();
                control.Attributes["data-hide-count"] = control.Source.HideCount().ToString();

                if (control is HideDependentCheckbox)
                {
                    control.Class = "scContentControlCheckbox hide-dependent-fields";
                }
                else
                {
                    control.Attributes["data-hide-values"] = control.Source.ValuesToHide();
                    control.Class = "scContentControl hide-dependent-fields";
                }
            }
        }

        private static string HideByDefault(this string Source)
        {
            return StringUtil.ExtractParameter("HideByDefault", Source).Trim();
        }

        private static int HideCount(this string Source)
        {
            var hideCount =  StringUtil.ExtractParameter("HideCount", Source).Trim();
            return MainUtil.GetInt(hideCount, 0);
        }

        private static string ValuesToHide(this string Source)
        {
            return StringUtil.ExtractParameter("ValuesToHide", Source).Trim();
        }
    }
}
