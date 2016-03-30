app.controller('adminTempostController', function ($scope, $sce) {

    this.inputValue = "";
    this.displayHtml = $sce.trustAsHtml(this.inputValue);
});

// html filter (render text as html)
app.filter('html', ['$sce', function ($sce) {
    return function (text) {
        return $sce.trustAsHtml(text);
    };
}])

angular.module('ck', []).directive('ckEditor', function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            var ck = CKEDITOR.replace(elm[0]);

            if (!ngModel) return;

            ck.on('pasteState', function () {
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            });

            ngModel.$render = function (value) {
                ck.setData(ngModel.$viewValue);
            };
        }
    };
});