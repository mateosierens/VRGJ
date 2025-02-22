using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallConditions : MonoBehaviour
{
    
    private Detector leftDectector;
    private Detector rightDectector;
    private Detector headDectector;

    public event Action OnWallPassed;
    private readonly Dictionary<CollisionZone, bool> _conditions = new()
    {
        { CollisionZone.Head, false },
        { CollisionZone.LeftHand, false },
        { CollisionZone.RightHand, false }
    };

    private void Start()
    {
        leftDectector = GetDetector("CollisionDetectorLeft");
        rightDectector = GetDetector("CollisionDetectorRight");
        headDectector = GetDetector("CollisionDetectorHead");
    }

    private Detector GetDetector(string name)
    {
        var detector = transform.Find(name).gameObject.GetComponent<Detector>();
        detector.succesfullHit += OnTargetCollision;
        return detector;
    }

    private void CheckConditions()
    {
        if (_conditions.All(c => c.Value))
        {
            OnWallPassed.Invoke();
        }
    }

    public void OnTargetCollision(CollisionZone e)
    {
        _conditions[e] = true;
        CheckConditions();
    }
}
