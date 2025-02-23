using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class WallConditions : MonoBehaviour
{
    
    [CanBeNull] private Detector leftDectector;
    [CanBeNull] private Detector rightDectector;
    [CanBeNull] private Detector headDectector;

    public event Action<GameObject> OnWallPassed;
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
        Detector detector = transform.Find(name).gameObject.GetComponent<Detector>();
        detector.succesfullHit += OnTargetCollision;
        return detector;
    }

    private void CheckConditions()
    {
        if (_conditions.All(c => c.Value))
        {
            OnWallPassed.Invoke(gameObject);
        }
    }

    public void OnTargetCollision(CollisionZone e)
    {
        _conditions[e] = true;
        CheckConditions();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnWallPassed.Invoke(gameObject);
        }
    }
}
