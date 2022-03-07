using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    public GameObject item;
    
    private GameObject tempParent;
    private Transform guide;
    private GameObject sheepParent;

    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        sheepParent = transform.parent.gameObject;
        tempParent = GameObject.FindWithTag("guide");
        guide = tempParent.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
    }
    
    void OnMouseUp() {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = sheepParent.transform;
        item.transform.position = guide.transform.position;

    }
}
