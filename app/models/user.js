 var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var bcrypt = require('bcrypt-nodejs');

//create Schema
var UserSchema = new Schema({
  username:String,
  password:String,
  email:String
});
 

// before saving schema do that(bcrypt password) 
UserSchema.pre('save', function (next) {
  var bcryptUserPassword = this;
  bcrypt.hash(bcryptUserPassword.password,null,null,function(err,hash){
    if (err) {
      console.log(err);
    }
    bcryptUserPassword.password = hash;
    next();
  })
  
})

UserSchema.methods.comparePassword = function(password){
  // console.log(password)
  //return bcrypt.compareSync(password, this.password);
  return bcrypt.compareSync(password, this.password); // true


}
// bcrypt.hash("bacon", null, null, function(err, hash) {
//     // Store hash in your password DB.
// });
  var user = mongoose.model('user', UserSchema);
// export module
module.exports = user;

 
