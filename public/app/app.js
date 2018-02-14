var app = angular.module('userApp', ['appRoutes','userControllers',"userServices","ngAnimate",'mainControllers','authServices'])
// app.controller('myCtrl', function($scope) {
//     $scope.name = "John Doe";
// });
app.config(function($httpProvider){
	// $httpProvider.intersepters.push('intersept');
	console.log("hiiiii")
	$httpProvider.interceptors.push('intersept');
})