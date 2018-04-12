
app.controller('gitCtrl', function ($http, $scope) {
    console.log("hiiiiget" + $scope.get);
   
        $http.get("http://localhost:54185/api/Home")
     
            .then(function (data) {
                
                $scope.booking = data.data;
                //console.log($scope.booking);
              
                //alert(JSON.stringify(data.data));
                console.log(data.data)
               
            }).catch(function (error) {
                console.log(error);
        });
    $scope.deleteBook = function (id) {
        console.log("my///////////// id"+id);
        
        $http.post("http://localhost:54185/api/Home/delete/" + id)
            .then(function (data) {
                alert("are you sure");
                console.log(data);
            });
    }
        
      
})