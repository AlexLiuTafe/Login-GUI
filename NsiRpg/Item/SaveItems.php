<?php
ob_start();
// Create server variable
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";

//user input variables
    $items = $_POST["items"];
    $username = $_POST["username"];
    //echo $username;

//check connection
    $conn = new mysqli($server_name, $server_username, $server_password, $database_name);
    if (!$conn)
    {
        echo "failed to connect to ".$server_name." :".mysqli_connect_error();
    }
    else
    {
        //echo "Connection success - " .$database_name." \n";
    }

// make sql
    $saveItemQuery = "UPDATE users SET items = '".$items."' WHERE username = '".$username."'";
    //echo $saveItemQuery;
    $saveItemResult = mysqli_query($conn, $saveItemQuery) or die("Failed to Items -  ".$username);
