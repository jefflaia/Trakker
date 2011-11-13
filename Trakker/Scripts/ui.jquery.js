(function ($) {
    $.fn.tDatePicker = function (options) {

        var defaultOptions = {}

        this.each(function () {
            $(this).datepicker($.extend(defaultOptions, options));
        });

        return this;
    };
})(jQuery);