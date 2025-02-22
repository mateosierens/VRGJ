using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Events;

public class Dectector : MonoBehaviour
{
    public List<Material> materials;
    private int counter;
    public CollisionZone assignedController;
    public event Action<CollisionZone> succesfullHit;

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
        Debug.Log(assignedController.ToString() + ", " + other.tag);
        if(assignedController.ToString() == other.tag) NextColour();
    }
    

    private void NextColour()
    {
        succesfullHit?.Invoke(assignedController);
        if (counter + 1 == materials.Capacity) counter = 0;
        else counter++;
        gameObject.GetComponent<MeshRenderer>().material = materials[counter];
        Debug.Log("Counter:" + counter + ", Capacity" + materials.Capacity);
    }
}
