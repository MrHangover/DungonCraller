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
    [SerializeField]
    Vector2 _minMaxRoomTileSize = new Vector2(4, 20);

    [Tooltip ("Prefabs")]
    [SerializeField]
    GameObject _floor;
    [SerializeField]
    GameObject _wall;


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

    public Sprite _floorSprite;
    public Sprite _wallSprite;
    public Sprite _cornerSprite;

    RoomIdentity GenerateSingleRoom (bool firstRoom)
    {
        //Skeleton structure
        GameObject room = new GameObject ();
        room.transform.position = Vector3.forward * -20;
        room.name = "room";
        RoomIdentity roomIdentity = room.AddComponent<RoomIdentity> ();
        roomIdentity.gmref = room;

        //Room Dimension Generation
        int roomWidth = Mathf.CeilToInt(Random.value * (_minMaxRoomTileSize.y - _minMaxRoomTileSize.x));
        int roomHeight = Mathf.CeilToInt(Random.value * (_minMaxRoomTileSize.y - _minMaxRoomTileSize.x));

        //Floor
        GameObject floor = Instantiate (_floor, Vector3.zero, Quaternion.identity, room.transform);
        floor.transform.localPosition = Vector3.zero;
        RoomGeography floorScript = floor.GetComponent<RoomGeography> ();
        floorScript.SetSprite (_floorSprite);
        floorScript.SetSize (new Vector3 (roomWidth * _tileSize, roomHeight * _tileSize));

        //Walls
        MakeWall (roomWidth * _tileSize, 0, ((roomHeight * _tileSize) / 2) + _tileSize / 2, 0, room);
        MakeWall (roomHeight * _tileSize, ((-roomWidth * _tileSize) / 2) - _tileSize / 2, 0, 90, room);
        MakeWall (roomWidth * _tileSize, 0, ((-roomHeight * _tileSize) / 2) - _tileSize / 2, 180, room);
        MakeWall (roomHeight * _tileSize, ((roomWidth * _tileSize) / 2) + _tileSize / 2, 0, -90, room);

        //Corners
        MakeCorner (((roomWidth * _tileSize) / 2) + _tileSize / 2, ((roomHeight * _tileSize) / 2) + _tileSize / 2, -90, room);
        MakeCorner (((-roomWidth * _tileSize) / 2) - _tileSize / 2, ((-roomHeight * _tileSize) / 2) - _tileSize / 2, 90, room);
        MakeCorner (((-roomWidth * _tileSize) / 2) - _tileSize / 2, ((roomHeight * _tileSize) / 2) + _tileSize / 2, 0, room);
        MakeCorner (((roomWidth * _tileSize) / 2) + _tileSize / 2, ((-roomHeight * _tileSize) / 2) - _tileSize / 2, 180, room);


        //Let the room generate its content
        roomIdentity.GenerateContent ();

        return roomIdentity;
    }

    void MakeWall(float xSize, float posX, float posY, float rotation, GameObject room)
    {
        GameObject wall = Instantiate (_wall, Vector3.zero, Quaternion.identity, room.transform);
        wall.transform.localPosition = new Vector3 (posX, posY, 0);
        wall.transform.rotation = Quaternion.Euler (0, 0, rotation);
        RoomGeography wallScript = wall.GetComponent<RoomGeography> ();
        wallScript.SetSprite (_wallSprite);
        wallScript.SetSize (new Vector3 (xSize, _tileSize));
    }

    void MakeCorner (float posX, float posY, float rotation, GameObject room )
    {
        GameObject corner = Instantiate (_wall, Vector3.zero, Quaternion.identity, room.transform);
        corner.transform.localPosition = new Vector3 (posX, posY, 0);
        corner.transform.rotation = Quaternion.Euler (0, 0, rotation);
        RoomGeography wallTopScript = corner.GetComponent<RoomGeography> ();
        wallTopScript.SetSprite (_cornerSprite);
        wallTopScript.SetSize (new Vector3 (_tileSize, _tileSize));
    }
}