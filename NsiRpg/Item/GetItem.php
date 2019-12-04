<?php
ob_start();
// Create server variable
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";

//user input variables
    $username = $_POST["username"];

//check connection
    $conn = new mysqli($server_name, $server_username, $server_password, $database_name);
    if (!$conn)
    {
        die("Connection failed.".mysqli_connect_error());
    }

    //http://localhost:81/nsirpg/item/GetItem.php

    //query
    $getItemsQuery = "SELECT items FROM users WHERE username = '".$username."'";
    $getItemsResult = mysqli_query($conn, $getItemsQuery);
//    $itemArray = Array();
    ob_end_clean();
    

//    if (mysqli_num_rows($getItemsResult) > 0)
//    {
//        //echo nl2br(mysqli_num_rows($getItemsResult));
//        //while($row = $getItemsResult->fetch_array(MYSQLI_ASSOC))
//        //{
//            //$myArray[] = $row;
//        //}
//        while ($row = mysqli_fetch_assoc($getItemsResult))
//        {
//            $itemArray[] = $row;
//        }
//        echo json_encode($itemArray);
//    }
//    else
//    {
//        echo "0";
//    }

//extract salt and hash from query result from above
    $existingInfo = mysqli_fetch_assoc($getItemsResult);
    $returnedItems = $existingInfo["items"];
    echo $returnedItems;
