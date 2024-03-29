﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region for sending email
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
#endregion

public class Login : MonoBehaviour
{
    [Header("Create User")]
    public InputField createNewUsername;
    public InputField createNewPassword;
    public InputField createNewEmail;
    [Header("Login")]
    public InputField loginUsername;
    public InputField loginPassword;
    [Header("Forgot Account")]
    public InputField emailName;
	public InputField userName;
	[Header("Notifications")]
	public GameObject incorrectPassword;
	public GameObject usernameExist;

	//IN ORDER TO CONNECT PHP TO XAMPP
	//NOTE * PHP FILES NEED TO BE PLACE IN XAMPP FOLDER IN HTDOCS FOLDER


	//Variables
	private string _characters = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string _code = "";
    

    #region variables
    //public bool createMenu, forgotMenu, playerAcc, characterCreate, inputCode, createPassword;

    #endregion
    #region IEnumerator
    IEnumerator CreateUser(string username, string password, string email)
    {
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
		form.AddField("password", password);
		form.AddField("email", email);
		UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();
		Debug.Log(webRequest.downloadHandler.text);
		if(webRequest.downloadHandler.text == "Username is Exist")
		{
			//Debug.Log("Username Exists");
			usernameExist.SetActive(true);
		}
		
	}

    IEnumerator UserLogin(string username, string password)
    {
        string loginUserURL = "http://localhost/nsirpg/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(loginUserURL, form);
        yield return webRequest.SendWebRequest();
        //Debug.Log(webRequest.downloadHandler.text); //Print debug.log in unity console from the database.

		if (webRequest.downloadHandler.text == "Login Successful")
		{
			//Change scene
			SceneManager.LoadScene(1);

		}
		else if (webRequest.downloadHandler.text == "Password Incorrect")
		{

			Debug.Log("Incorrect Password");
			incorrectPassword.SetActive(true);
		}

		else
		{
			Debug.Log("Login Error/ID NOT FOUND");
		}

    }
    IEnumerator CheckEmail(string email, string username)
    {
        string checkEmailURL = "http://localhost/nsirpg/checkemail.php";
        WWWForm form = new WWWForm();
        form.AddField("email_Post", email);
        UnityWebRequest webRequest = UnityWebRequest.Post(checkEmailURL, form);
        yield return webRequest.SendWebRequest();
        if (webRequest.downloadHandler.text == "User Not Found")
        {
            Debug.Log("User Not Found");
        }
        else
        {
            SendEmail(email, username);
        }
    }
    #endregion
    #region FUNCTION
    public void CreateNewUser()
    {
		// NOTE*				Need to paste argument in correct order from the FUNCTION
        StartCoroutine(CreateUser(createNewUsername.text,createNewPassword.text ,createNewEmail.text));
	
    }

    public void AttemptUserLogin()
    {
		//Store the User ID on Loading Scene
		KeepOnLoad.userIdOnLoad = loginUsername.text;
        StartCoroutine(UserLogin(loginUsername.text, loginPassword.text));
    }
    public void AttempCheckEmail()
    {
        StartCoroutine(CheckEmail(emailName.text,userName.text));
    }
    public void SendEmail(string email, string username)
    {
        RandomCodeGenerator();
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(email);
        mail.Subject = "NSIRPG Password Reset";
        mail.Body = "Hello" + " " + username + "\nReset using this code: " + _code;
        //Connect to google
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        //Be able to send through ports
        smtpServer.Port = 25;
        //Login to google
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };
        //Send message
        smtpServer.Send(mail);
        Debug.Log("Sending Email");
        Debug.Log(_code);

    }
    public string RandomCodeGenerator()
    {
        for (int i = 0; i < 20; i++)
        {
            int a = UnityEngine.Random.Range(0, _characters.Length);
            _code = _code + _characters[a];
        }
        return _code;


    }
    #endregion

}

