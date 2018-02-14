var app = angular.module('authServices',[]);
app.factory('Auth',function($http,authToken){
	authFactory = {};
	authFactory.login = function(loginData){
		return $http.post("/authenticate",loginData).then(function(data){
			console.log(data);
			authToken.setToken(data.data.token)
			return data;
		})
	}
	authFactory.isLoggedIn = function(){
		if(authToken.getToken()){
			return true;
		}
		else{
			return false;
		}
	}


	authFactory.getUser=function(){
		if(authToken.getToken()){
			var newToken = authToken.getToken();
			return $http.post('/me');
		}
		else{ 
			console.log("no toooken");
			$q.reject({message:"no tooooookkkkkekekek"})

		};

	}
	return authFactory;
	
});

app.factory('authToken',function($window){
	var authTokenFactory = {};
	authTokenFactory.setToken = function(token){
	$window.localStorage.setItem('setToken',token)
	}
	authTokenFactory.getToken = function(){
		return $window.localStorage.getItem('setToken')
	}
	authTokenFactory.logout = function(){
		$window.localStorage.removeItem('setToken')
	}
	return authTokenFactory;
})

app.factory('intersept',function(authToken){
	console.log('interseptttt')
	var authInterceptor = {};
	authInterceptor.request = function(config
		){
		//console.log("auth token value"+authToken.getToken());
		if(authToken.getToken()){
			console.log("if interceptor");
		}
			config.headers['x-access-token'] = authToken.getToken();

			return config

	};
	return authInterceptor;
})
