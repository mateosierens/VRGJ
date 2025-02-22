using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class Dectector : MonoBehaviour
{
    public Collider collider;
    public List<Material> materials;
    private int counter;
    public String assignedController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if(assignedController == other.tag) NextColour();
    }
    

    private void NextColour()
    {
        if (counter + 1 == materials.Capacity) counter = 0;
        else counter++;
        gameObject.GetComponent<MeshRenderer>().material = materials[counter];
        Debug.Log("Counter:" + counter + ", Capacity" + materials.Capacity);
    }
}
