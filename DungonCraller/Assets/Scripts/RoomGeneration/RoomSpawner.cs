using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomSpawner : MonoBehaviour {
    [SerializeField]
    float _tileSize = 20f;
    public static UnityEvent LevelGeneratedEvent = new UnityEvent();
    public static bool LevelGenerated { get { return _startLevelGenerated; } }
    [SerializeField]
    static bool _startLevelGenerated = false;
    [SerializeField]
    Vector2 _minMaxRoomsBeforeNextLevel = new Vector2(10, 40);


    // Use this for initialization
    void Start ()
    {
        GenerateFirstRoom ();
        RecursivePopulateSpace ();

        _startLevelGenerated = true;
        LevelGeneratedEvent.Invoke();
	}


    void GenerateFirstRoom ()
    {
        RoomIdentity room = GenerateSingleRoom (true);
        room.gmref.transform.position = Vector3.zero;
    }


    void RecursivePopulateSpace ()
    {
        
    }


    RoomIdentity GenerateSingleRoom (bool firstRoom)
    {
        //Skeleton structure
        GameObject room = new GameObject ();
        room.transform.position = Vector3.forward;
        room.name = "room";
        RoomIdentity roomIdentity = room.AddComponent<RoomIdentity> ();
        roomIdentity.gmref = room;

        //Room Dimension Generation
        

        //Let the room generate its content
        roomIdentity.GenerateContent ();

        return roomIdentity;
    }
}