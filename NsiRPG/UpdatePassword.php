<?php
	//Server login variables
	$server_name = "localhost";
	$server_username = "root";
	$server_password = "";
	$database_name = "nsirpg";
	
	$password = $_POST["password_Post"];
	$username = $_POST["username_Post"];;
	//Check connection
	$conn = new mysqli($server_name,$server_username,$server_password,$database_name);
	if($!conn)
	{
		die("Connection Failed."mysqli_connect_error());
	}
	
	//http://localhost/nsirpg/updatepassword.php
	
	//Change password by creating new hash
	$salt = "\$5\$round=5000\$"."supercalifragilisticexpialidocious".$username."\$";
	$hash = crypt($password,$salt);
	
	$updatePassword = "UPDATE users SET salt, hash = '".$hash."','".$salt."'WHERE username = '".$username."';";
	$updateResult = mysqli_query($conn, $updatePassword) or die("error insert failed");
	if($updateResult)
	{
		echo "Password Changed";
	}

?>