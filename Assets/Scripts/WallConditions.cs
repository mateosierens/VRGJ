using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class WallConditions : MonoBehaviour
{
    
    private Dectector leftDectector;
    private Dectector rightDectector;
    private Dectector headDectector;
    private void Start()
    {
        leftDectector = transform.Find("CollisionDetectorLeft").gameObject.GetComponent<Dectector>();
        rightDectector = transform.Find("CollisionDetectorRight").gameObject.GetComponent<Dectector>();
        headDectector = transform.Find("CollisionDetectorHead").gameObject.GetComponent<Dectector>();
        leftDectector.succesfullHit += OnTargetCollision;
        rightDectector.succesfullHit += OnTargetCollision;
        headDectector.succesfullHit += OnTargetCollision;
    }

    public UnityEvent wallPassedEvent;
    private readonly Dictionary<CollisionZone, bool> _conditions = new()
    {
        { CollisionZone.Head, false },
        { CollisionZone.LeftHand, false },
        { CollisionZone.RightHand, false }
    };

    private void CheckConditions()
    {
        if (_conditions.All(c => c.Value))
        {
            wallPassedEvent.Invoke();
        }
    }

    public async void OnTargetCollision(CollisionZone e)
    {
        _conditions[e] = true;
        CheckConditions();
        await Task.Delay(1000);
        _conditions[e] = false;
    }

    public void onCollisionZoneHit(String area)
    {
        Debug.Log("Hit!!!");
        return;
    }
    
}
