﻿//Manage Calendar format
function SetCalendarDatePicker(root) {
    if (root.find(".calendarPicker").length > 0) {
        root.find('.calendarPicker').datepicker({ format: cultureFormatDate, language: cultureShort });
    }
    if ($.validator != null) {
        $.validator.methods.date = function (value, element) {
            var dpg = $.fn.datepicker.DPGlobal;
            return this.optional(element) || dpg.parseDate(value, dpg.parseFormat(cultureFormatDate)) !== null;
        }
    }
}

function SetFloatValidator() {
    if ($.validator != null) {
        $.validator.methods.range = function (value, element, param) {
            var globalizedValue = value.replace(",", ".");
            return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
        }

        $.validator.methods.number = function (value, element) {
            return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
        }
    }
}


$(document).ready(function () {
    SetCalendarDatePicker($(document));
    SetFloatValidator();
    //Calendar format in Dialog
    $(window).on('OnBIADialogLoaded', function (e) {
        SetCalendarDatePicker(e.dialog);
        SetFloatValidator();
    });
    $(window).on('OnBIADialogResize', function (e) {
        ResizeDialog(e.dialog);
    });
});