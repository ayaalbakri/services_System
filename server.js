var express = require('express');
var app = express();
var morgan = require('morgan')
var mongoose = require('mongoose');
var users = require('./app/models/user');
const path = require('path');
var bodyParser=require('body-parser');
var jwt = require('jsonwebtoken');
var secret = "aya";
app.use(morgan('dev'));
app.use( bodyParser.urlencoded({extended : true }));
app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, 'public')));
mongoose.connect('mongodb://127.0.0.1:27017/test',function(error){
	if (error) {
		console.log('error in connection with database');
	}
	else{
		console.log('connect with db')
	}
});


var db = mongoose.connection;
// console.log("/////",db);


app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});
// app.use(function (req,res,next){
//      if (req.method === 'OPTIONS') {
//           var headers = {};
//           // IE8 does not allow domains to be specified, just the *
//           // headers["Access-Control-Allow-Origin"] = req.headers.origin;
//           headers["Access-Control-Allow-Origin"] = "*";
//           headers["Access-Control-Allow-Methods"] = "POST, GET, PUT, DELETE, OPTIONS";
//           headers["Access-Control-Allow-Credentials"] = false;
//           headers["Access-Control-Max-Age"] = '86400'; // 24 hours
//           headers["Access-Control-Allow-Headers"] = "X-Requested-With, X-HTTP-Method-Override, Content-Type, Accept";
//           res.writeHead(200, headers);
//           res.end();
//     }
// });
app.get('/',function(req,res){
	res.sendFile( __dirname + "/public/app/views/" + "index.html" );
})

app.post('/user',function(req,res){
	var userr = new users ({
			username: req.body.username,
			password:req.body.password ,
			email: req.body.email });
		if(req.body.username==null ||req.body.username==""||req.body.password==null||req.body.password==""||
			req.body.email==null||req.body.email==""){
			// res.send("field cant be empty");
			res.json({success:false,massage:"field cant be empty"});
		}
		else{
			userr.save(function(err,user){
				if (err) {
					console.log("erroe happen"+err);
				}
				else{
					console.log("new user added");
					// res.send("new user creted " + user);
					res.json({success:true,massage:"new user creted "});
				}

			})};
		
		});

app.post('/authenticate',function(req,res){
	  users.findOne( { username:req.body.username } ).select('email username password').exec(function(err, user){
				   if (err) throw err;

          if (!user) {
              res.json({ success: false, message: 'Could not authenticate' });
          } else if (user) {
          	//console.log(user.comparePassword)
              if (req.body.password) {
                  var validPassword = user.comparePassword(req.body.password);
                  if (!validPassword) {
                      res.json({ success: false, message: 'Could not validate Password' });
                  } else {
                  	   var token = jwt.sign({username:user.username,email:user.email}, secret, { expiresIn: '48h' });
              	       console.log("toooookeeen"+token)
                      res.json({ success: true, message: 'User Authenticate' , token : token});
                  }
              } else {
                  res.json({ success: false, message: 'No password provided' });
              }
          }
      });
  });


// token midlware
app.use(function(req, res, next) {

  // check header or url parameters or post parameters for token
  var token = req.body.token || req.query.token || req.headers['x-access-token'];

  // decode token
  if (token) {

    // verifies secret and checks exp
    jwt.verify(token, secret, function(err, decoded) {      
      if (err) {
         res.json({ success: false, message: 'Failed to authenticate token.' });    
      } else {
        // if everything is good, save to request for use in other routes
        // req.decoded have user information in this case have username and email
        req.decoded = decoded;    
        next();
      }
    });

  } else {

    // if there is no token
    // return an error
     res.status(403).send({ 
        success: false, 
        message: 'No token provided.' 
    });

  }
});
app.post('/me',function(req,res){
	console.log(req.decoded)
	res.send(req.decoded)
})

//get all users
app.get('/user',function(req,res){
	users.find({},function(err,data){
		console.log(data);
		res.send(200,data);
	})
})



app.listen(process.env.PORT || 3000, () => console.log('Example app listening on port 3000!'));


