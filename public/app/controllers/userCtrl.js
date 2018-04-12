var app = angular.module('userControllers', [])
app.controller('regCtrl',function($http,$location,$timeout,user){
	this.regUser=function(regData){
		var that = this;
		that.errorMsg = false;
		that.successMsg = false;
		that.loading = true;
		// console.log(this.regData)
		// $http({
  //       method: 'POST',
  //        url: '/user',
		//  headers: {
		//    'Content-Type': 'application/json'
		//  },
		//  data: {
		//  	username:this.regData.username,
		//  	password:this.regData.password,
		//  	email:this.regData.email
		//  	 }
  //   }).then(function mySuccess(response) {
  //       console.log("mySuccess"+response.data)
  //   }, function myError(response) {
  //      console.log("myError"+response)
  //   });

  
  // user is sevice ***////
  user.create(this.regData).then(function(data){
  	console.log(data.data.success)
  	 if (data.data.success) {
  	that.successMsg = data.data.massage;
  	that.loading = false;
  	// $location.path to redirect to anther page when we click in button
  	// $timeout to dalay redirect after 1000 ms
  	$timeout(function() {
  		$location.path('/');
  	}, 1000);
  	
  }
  else{
  	that.errorMsg = data.data.massage;
  	that.loading = false;
  }
  });

    }
    this.get = function () {
        $http.get("http://localhost:54185/api/Home")
            .then(function (response) {
              connsole.log("husaaaammmmmiaaaaa"+response)
            });
    }
})
