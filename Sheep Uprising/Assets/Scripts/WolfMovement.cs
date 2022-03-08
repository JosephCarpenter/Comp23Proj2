using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfMovement : MonoBehaviour
{
    public GameObject plane;
    private Transform target;
    
    private float minPos; 
    private float maxPos;
    
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        minPos = -(plane.transform.localScale.x*5) + transform.localScale.x;
        maxPos = (plane.transform.localScale.x*5) - transform.localScale.x;
        transform.position = new Vector3(Random.Range(minPos,maxPos), transform.localScale.y/2,Random.Range(minPos,maxPos));
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene("EndLose");
        }
    }
}
