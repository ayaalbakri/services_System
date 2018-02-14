var app = angular.module('appRoutes', ['ngRoute']);
app.config(function($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl : 'app/views/pages/home.html'
    })
    .when("/login", {
        templateUrl : 'app/views/pages/users/login.html'

    })
    .when('/logout',{
    	templateUrl:'app/views/pages/users/logout.html'
    })
    .when("/register",{
    	templateUrl:'app/views/pages/users/register.html',
    	controller : 'regCtrl',
    	controllerAs:'register'
    })

    .otherwise({
    	redirectTo : '/'
    })
});