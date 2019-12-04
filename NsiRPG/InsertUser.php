<?php
//Server Login variables
	$server_name = "localhost";
	$server_username = "root";
	$server_password ="";
	$database_name ="nsirpg";
	
	
//user variables
$username = $_POST["username"]; //Sending information from Unity in form of username
$password =$_POST["password"];
$email = $_POST["email"];


//check connection
	$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
	if(!$conn)
	{
		die("Connection Failed.".mysqli_connect_error());
	}
	//http://localhost/nsirpg/insertuser.php 
	
	
//$ sign is variables we created

//check users exist
//Looking for data from "users" table,column named "username"   Variable in this script //dot is a + (in string)
$namecheckquery ="SELECT username FROM users WHERE username = '".$username."';";
$namecheck = mysqli_query($conn,$namecheckquery);
if(mysqli_num_rows($namecheck)>0)
{
	echo "Username is Exist";
	exit(); // same like return
	
}
//check email exist
$emailcheckquery = "SELECT email FROM users WHERE email = '".$email."';";
$emailcheck = mysqli_query($conn,$emailcheckquery);
if(mysqli_num_rows($emailcheck)>0)
{
	echo "Email is Exist";
	exit();
	
}

//create user
$salt = "\$5\$round=5000"."thisissohardandconfusing".$username."\$";
$hash = crypt($password,$salt);
//                                     string from the xampp tables		variables in this script
$insertuserquery = "INSERT INTO users (username,email,hash,salt)VALUES('".$username."','".$email."','".$hash."','".$salt."');";
mysqli_query($conn,$insertuserquery) or die("error insert failed");
echo "Success";

?>