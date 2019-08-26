<?php
//Server Login variables
	$server_name = "localhost";
	$server_username = "root";
	$server_password ="";
	$database_name ="nsirpg";
	
	$email = $_POST["email_Post"];
	
//user variables
$username = $_POST["username"]; //Sending information from Unity in form of username
$password =$_POST["password"];

//check connection
	$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
	if(!$conn)
	{
		die("Connection Failed.".mysqli_connect_error());
	}
	//http://localhost/nsirpg/login.php 

//check user exist
$namecheckquery = "SELECT username, salt, hash FROM users WHERE username = '".$username."';";
$namecheck = mysqli_query($conn, $namecheckquery);
if(mysqli_num_rows($namecheck)!=1)
{
	echo "Error";
	exit();
	
}

//get login from query
$existinginfo = mysqli_fetch_assoc($namecheck);
$salt =$existinginfo["salt"]; // $salt is from the table "salt"
$hash =$existinginfo["hash"];

$loginhash = crypt($password, $salt); //getting the password from unity and salt from the table
if($hash != $loginhash)
{
	echo "Password Incorrect";
	exit();
}
else
{
	echo "Login Successful";
	exit();
	
}

?>