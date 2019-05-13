using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatPoint : MonoBehaviour {
    private PlayerController thePlayer;
    private CameraController theCamera;
    public Vector2 startDirection;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        thePlayer.lastMove = startDirection;
        thePlayer.transform.position = transform.position;
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
