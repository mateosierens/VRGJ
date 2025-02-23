using System;
using System.Collections.Generic;
using System.Diagnostics;
using Inputs;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Detector : MonoBehaviour
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
        if(other.CompareTag(assignedController.ToString())) NextColour();
    }
    

    private void NextColour()
    {
        succesfullHit?.Invoke(assignedController);
        
        switch (assignedController)
        {
            case CollisionZone.LeftHand:
                InputManager.Instance.sendHaptics(SideController.LeftHand, 0.3f, 0.5f);
                break;
            case CollisionZone.RightHand:
                InputManager.Instance.sendHaptics(SideController.RightHand, 0.3f, 0.5f);
                break;
            case CollisionZone.MainCamera:
                break;
        }

        if (counter + 1 == materials.Capacity) counter = 0;
        else counter++;
        gameObject.GetComponent<MeshRenderer>().material = materials[counter];
        Debug.Log("Counter:" + counter + ", Capacity" + materials.Capacity);
        
        
    }
}
