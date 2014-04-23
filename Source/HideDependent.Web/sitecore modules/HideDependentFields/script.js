//*****************************************************
// Author: Kamruz Jaman
// Twitter: @jammykam
// Date: 10/04/2014
// Hide dependent fields based on selected value
//*****************************************************

function HideDependentFields(element, useEffects) {
    
    var action = 'show',
        $element = $(element),
        hideByDefault = $element.readAttribute('data-hide-default'),
        hideCount = $element.readAttribute('data-hide-count'),
        hideValues = $element.readAttribute('data-hide-values'),
        siblingElements = $element.up('.scEditorFieldMarker').nextSiblings();

    // get array of elements to be hidden
    if (hideCount > 0 && siblingElements.length > hideCount) {
        siblingElements = siblingElements.slice(0, hideCount);
    }
    
    // for checkbox type elements check if checked
    if (element.type == 'checkbox') {
        if ((!element.checked && hideByDefault == 'true') || (element.checked && hideByDefault == 'false')) {
            action = 'hide';
        }
    }

    // for select elements check the selected value
    if (element.nodeName.toLowerCase() == 'select') {
        var elVal = $element.getValue();
        if (hideByDefault && elVal == '') {
            action = 'hide';
        }
        else if (hideValues.length > 0) {
            var arrValues = hideValues.split('|');
            if (arrValues.indexOf(elVal) != -1) {
                action = 'hide';
            }
        }
    }

    // hide immediatelty if firing from DOM Load event
    if (!useEffects) {
        siblingElements.invoke(action);
        return;
    }

    // otherwise use fade effects
    var effectFn = (action == 'show') ? function(el) { el.appear({ duration: 0.5 }) } : function(el) { el.fade({ duration: 0.5 }) };
    Effect.multiple(siblingElements, effectFn, { speed: 0 });

};

// add script to be called when content editor is loaded
document.observe("sc:contenteditorupdated", function(event) {
    $$('.hide-dependent-fields').each( function(element, index) {
        HideDependentFields(element, false);
    });
});