using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomIdentity : MonoBehaviour {
    public GameObject gmref;
    public bool ContentGenerated { get; private set; }


    public void Awake ()
    {
        ContentGenerated = false;
    }


    public void GenerateContent()
    {
        if(!ContentGenerated)
        {


            ContentGenerated = true;
        }
    }
}
