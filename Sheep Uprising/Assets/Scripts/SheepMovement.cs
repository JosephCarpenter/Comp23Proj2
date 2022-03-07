using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    public GameObject plane;
    
    private float minPos; 
    private float maxPos;
    
    private Vector3 position;
    private Rigidbody rb;
    
    public int speedUpperBound;
    public int speedLowerBound;
    private float speed;
    private bool buildingSpeed;
    private float movementX;
    private float movementY;
    private Vector3 movement;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start() {
        // handle spawning in random position
        minPos = -(plane.transform.localScale.x*5) + transform.localScale.x;
        maxPos = (plane.transform.localScale.x*5) - transform.localScale.x;
        position = new Vector3(Random.Range(minPos,maxPos), transform.localScale.y/2,Random.Range(minPos,maxPos)); 
        transform.position = position;
        
        // assign movement vector
        rb = GetComponent<Rigidbody>();
        speed = 0;
        NewMovement();

        // For updating score
        if (GameObject.FindWithTag("GameController") != null) { gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController>();
        }
    
    }

    void FixedUpdate () {

		rb.AddForce(movement * speed);
        // rb.AddForce(new Vector3 (10, 0.0f, 10));
        
        if (buildingSpeed) {
            if (speed < speedUpperBound)
                speed += 0.1f;
            else
                buildingSpeed = false;
        }
        else {
            if (speed > speedLowerBound)
                speed -= 0.1f;
            else {
                NewMovement();
            }
        }
	}
    
    IEnumerator OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Finish") {
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
            gameController.AddScore (1); 
        }
    }

    void NewMovement() {
        buildingSpeed = true;
        movementX = Random.Range(-10, 10);
        movementY = Random.Range(-10, 10);
        movement = new Vector3 (movementX, 0.0f, movementY); 
    }
    
    
}
