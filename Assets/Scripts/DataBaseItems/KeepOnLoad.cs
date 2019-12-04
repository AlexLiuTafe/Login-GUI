using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{
    
    [SerializeField]
    public static string userIdOnLoad;
    //public GameObject myMan;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Survivor");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
