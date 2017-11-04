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

        float mouseRadius = Screen.height * 0.25f; //TODO avoid using hardcoded values
        Vector2 mouseInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 characterCenter = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 relativeMousePos = mouseInput - characterCenter;
        Vector2 normalizedMousePos = new Vector2(relativeMousePos.x / mouseRadius, relativeMousePos.y / mouseRadius);
        if(normalizedMousePos.magnitude > 1f)
        {
            normalizedMousePos.Normalize();
        }
        player.Attack(normalizedMousePos);
	}
}
