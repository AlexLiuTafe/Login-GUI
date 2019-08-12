using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField createNewUsername;
    public InputField createNewPassword;
    public InputField createNewEmail;

    public InputField loginUsername;
    public InputField loginPassword;

    
    IEnumerator CreateUser(string username, string password, string email)
    {
        string createUserURL = "http://localhost/nsirpg/insertuser.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();

    }

    IEnumerator UserLogin(string username, string password)
    {
        string loginUserURL = "http://localhost/nsirpg/login.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(loginUserURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text); //Print debug.log in unity console from the database.

        if (webRequest.downloadHandler.text == "Login Successful")
        {
            //Change scene
            SceneManager.LoadScene(1);
            
        }
        else
        {

            Debug.Log("Login Failed");
        }

    }
    public void CreateNewUser()
    {
        Debug.Log("New Account Created");
        StartCoroutine(CreateUser(createNewUsername.text,createNewEmail.text,createNewPassword.text));
    }

    public void AttemptUserLogin()
    {
        
        StartCoroutine(UserLogin(loginUsername.text, loginPassword.text));
        
    }
}

