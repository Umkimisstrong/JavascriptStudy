$(function () {
    app.initialize();

    // Knockout 활성화
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app, document.body);
});
