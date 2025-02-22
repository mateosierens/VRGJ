using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dectector : MonoBehaviour
{
    public Collider collider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hands")
        {
            Debug.Log("PeepeePooPoo");
        }
        throw new NotImplementedException();
    }
}
