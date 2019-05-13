using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeMovement : MonoBehaviour {
    public float moveSpeed;

    private Rigidbody2D myRigidBody;

    private bool moving;

    public float random1;
    public float random2;

    public float timeBetweenMove;

    public float timeToMove;

    private float timeBetweenMoveCounter;
    private float inactiveTimer;
    private bool reloading;
    private GameObject thePlayer;

    private float timeToMoveCounter;
    private Vector3 moveDirection;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        reloading = false;
        inactiveTimer = 1;
    }

    void Update() {
        if (moving) {
            timeToMoveCounter -= Time.deltaTime;
            myRigidBody.velocity = moveDirection;
            if (timeToMoveCounter < 0f) {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove * Random.Range(random1, random2);
            }
        } else {
            myRigidBody.velocity = Vector2.zero;
            timeBetweenMoveCounter -= Time.deltaTime;
            if (timeBetweenMoveCounter < 0f) {
                moving = true;
                timeToMoveCounter = timeToMove * Random.Range(random1, random2);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if (reloading) {
            inactiveTimer -= Time.deltaTime;
            if (inactiveTimer < 0f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.gameObject.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {        
        if (other.gameObject.name.Equals("Player")) {
            other.gameObject.SetActive(false);
            thePlayer = other.gameObject;
            reloading = true;

        }
    }
}
