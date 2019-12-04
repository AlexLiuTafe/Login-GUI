using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class SaveItems : MonoBehaviour
{
	//what do we save
	string user;
	string ItemsTosave; // we will concatinate all item ID from the inv List

	private void Start()
	{
		user = KeepOnLoad.userIdOnLoad; // this stores the user name from our log in scene that got passed to this scene.
		Debug.Log("Account Name : " + user + " is Connected");
	}


	IEnumerator Save(string _items, string _username)
	{
		//the url
		//Debug.Log("in save function");
		string createUserURL = "http://localhost/nsirpg/item/saveitems.php";
		WWWForm form = new WWWForm();
		form.AddField("items", _items);
		form.AddField("username", _username);

		UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

		yield return webRequest.SendWebRequest();

		string s = webRequest.downloadHandler.text;
		Debug.Log(s);
	}

	public void SaveItem()
	{
		// PUT all the item ID (INT) into an array of strings
		ItemsTosave = ""; //reset the string
		for (int i = 0; i < LinearCanvasInventory.inv.Count; i++)
		{
			ItemsTosave += LinearCanvasInventory.inv[i].ID;
		}

		Debug.Log(ItemsTosave);
		StartCoroutine(Save(ItemsTosave, user));
	}
}
