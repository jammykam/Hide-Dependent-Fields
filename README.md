Hide Dependent Fields Controls
==============================

Author: Kamruz Jaman 
<br />Twitter: @jammykam

Description
-----------
The Hide Dependent Fields module adds new Checkbox, Droplist and Droplink field type to the Sitecore Content Editor which depending on the selected value will hide the proceeding sibling fields. All controls  inherit from their equivalent Sitecore counterpart and add the required UI enhancements.

You can read more about it on this [blog post](http://jammykam.wordpress.com/2014/04/23/hiding-content-editor-fields-depending-on-selected-values)

Installation
------------
Download the package from the Release folder and install using the Installation Wizard in Sitecore.

Configuration
-------------
Configure the control by passing in parameters in the Source field of the Template.

**Usage:**
- In your template select the appropriate Hide Dependent Field type.
- For checkbox type, you must set HideDefault bool in the source.
- For the drop types, you must set HideDefault or HideValues in the source.
- If these values are not set then a standard control is rendered.
- If you need to set a datasource then set it using parameters, e.g. Datasource=/sitecore/content/home&HideDefault=true

**Values:**
- HideDefault: [boolean] - true/false value indicating whether the fields should be hidden by default (i.e. when checkbox is not checked or no value selected in select list)
- HideCount: [int] - number of siblings to hide. Default (or passing 0) means all.
- HideValues [string] - pipe (|) separated list of values that siblings should be hidden when selected, e.g. Item1|Item2 or {guid}|{guid}. Not applicable for checkbox type.

Release notes
-------------
*1.0.0*
- Initial release.
