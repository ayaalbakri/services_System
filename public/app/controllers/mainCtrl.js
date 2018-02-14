var app = angular.module('mainControllers', ['authServices'])
app.controller('mainCtrl',function($http,$location,$timeout,Auth,authToken,$rootScope){
	// isloggedin
	that = this;
	 //this.userN;

	// every time a new view loads check for the username variable
  $rootScope.$on('$routeChangeStart',function(){
    if(Auth.isLoggedIn()){
      console.log('Success: user is logged in.');
      Auth.getUser().then(function(data){
        console.log(data.data.username);
        that.userN = data.data.username;
      });
    }else {
      console.log('Failure: user is not logged in');
      that.userN = "";
    }

  });


	this.doLogin=function(loginData){
		var that = this;
		that.errorMsg = false;
		that.successMsg = false;
		that.loading = true;
  // user is sevice ***////
  Auth.login(this.loginData).then(function(data){
  	 if (data.data.success) {
  	 	// console.log(data)
  	that.successMsg = data.data.message;
  	that.loading = false;
  	// $location.path to redirect to anther page when we click in button
  	// $timeout to dalay redirect after 1000 ms
  	$timeout(function() {
  		$location.path('/');
  	}, 1000);
  	
  }
  else{
  	console.log(data.data.success)
  	that.errorMsg = data.data.message;
  	that.loading = false;
  }
  });

	}
	this.logout = function(){
		console.log("out");
		authToken.logout();
		$timeout(function() {
  		$location.path('/');
  	}, 1000);
  	
	}
})
