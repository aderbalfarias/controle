/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: PT_BR
 */
jQuery.extend(jQuery.validator.methods, {
    //date: function (value, element) {
    //    return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
    //},
    date: function (value, element) {
        return this.optional(element) || /^\d{2}\/\d{2}\/\d{4} \d{2}[:]\d{2}$/.test(value);
    },
    number: function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
    }
});
