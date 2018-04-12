var app = angular.module('userApp', ['appRoutes','userControllers',"userServices","ngAnimate",'mainControllers','authServices'])
// app.controller('myCtrl', function($scope) {
//     $scope.name = "John Doe";
// });
app.config(function () {
    // $httpProvider.intersepters.push('intersept');
   
    console.log("hiiiii")
    //$httpProvider.interceptors.push('intersept');
   
    
});
//app.use(allowCrossDomain);