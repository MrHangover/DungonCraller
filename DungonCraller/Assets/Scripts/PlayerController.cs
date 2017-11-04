using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour {
    Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        player.Move(input);

        float mouseRadius = Screen.height * 0.33f;
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        Vector2 relativeMousePos = mouseInput - screenCenter;
	}
}
