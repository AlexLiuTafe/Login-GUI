using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
//using TMPro; // for texmesh pro shit
//using UnityEngine.SceneManagement;
//using System.IO;
using SimpleJSON;
using System.Linq;

public class GetItems : MonoBehaviour
{

    string user;
    public GameObject buttonPrefab;
    public RectTransform parent;
    public string[] returnedItems;

    #region Internal
    void Start()
    {

		user = KeepOnLoad.userIdOnLoad;
        LoadItem();
    }

    void Update()
    {

    }
    #endregion

    #region External
    public IEnumerator GetAllItems(string _username)
    {
        string createUserURL = "http://localhost/nsirpg/item/GetItem.php";
        WWWForm form = new WWWForm();
        form.AddField("username", _username);

        //form.AddField("password", _password);

        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);

        yield return webRequest.SendWebRequest();
        //Debug.Log(webRequest.downloadHandler.text);

        //we want to convert the shit we got from our database to a JSON object
        //string jsonString = webRequest.downloadHandler.text;
        //JSONArray jsonArray = JSON.Parse(jsonString) as JSONArray;
        //Debug.Log(jsonArray[0].AsObject.Count);

        string s = webRequest.downloadHandler.text;
        //Debug.Log(s.Length);
		// ARRAY SPLITTER VARIABLE HERE and Assign Which String array we want to split
        IEnumerable<string> theItems = Split(s, 3);//We take 3 Digit of string 1 at a time
        string[] myarray = theItems.ToArray();//Store it into string of array and convert the them into array.

        for (int i = 0; i < myarray.Length; i++)
        {
            int id = 0;
			//Convert String value into Int
			if (!int.TryParse(myarray[i], out id))
			{
				Debug.Log("Error Parrsing Array");
			}

			LinearCanvasInventory.inv.Add(ItemData.CreateItem(id));//ASSIGN THE ITEM ID NUMBER AND ADD ITEM LIST
            int currentSlot = LinearCanvasInventory.inv.Count - 1;
            GameObject button = Instantiate(buttonPrefab, parent) as GameObject; //parent is the Gridlayout object
            button.GetComponent<SelectButton>().index = currentSlot;
            button.name = LinearCanvasInventory.inv[currentSlot].Name;
            button.GetComponentInChildren<Text>().text = LinearCanvasInventory.inv[currentSlot].Name;
        }

    }

	//LOAD ITEM FUNCTION
    public void LoadItem()
    {
        //Debug.Log(user);
        StartCoroutine(GetAllItems(user));
    }
	//WE ARE STORING THE ITEM ID NUMBER INTO ARRAT Ex: 400402400 Is Equal to 3 Items
	//THIS FUNCTION FOR SPLITING ARRAY INTO ASSIGNED DIGITS
    static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
    #endregion
}
