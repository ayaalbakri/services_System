var app = angular.module("userServices",[]);
app.factory('user',function($http){
	var userFactory = {}
	userFactory.create=function(regData){
		return $http.post('/user',regData)
	}
	return userFactory;
})