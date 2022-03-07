using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    public GameObject sheep;
    public int numSheep;
    
    void Start()
    {
         for (int i = 0; i < numSheep; i++) {
             GameObject newSheep = Instantiate(sheep) as GameObject;
             newSheep.transform.parent = transform;
         }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < numSheep) {
            GameObject newSheep = Instantiate(sheep) as GameObject;
            newSheep.transform.parent = transform;
        }
    }
}
