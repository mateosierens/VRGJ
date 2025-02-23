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
    public Transform playerPos;

    public event Action<GameObject> OnWallPassed;
    public event Action<GameObject> onWallFailed;
    private readonly Dictionary<CollisionZone, bool> _conditions = new()
    {
        { CollisionZone.MainCamera, false },
        { CollisionZone.LeftHand, false },
        { CollisionZone.RightHand, false }
    };

    private void Start()
    {
        leftDectector = GetDetector("CollisionDetectorLeft");
        rightDectector = GetDetector("CollisionDetectorRight");
        headDectector = GetDetector("CollisionDetectorHead");
        
        
        if (!leftDectector.gameObject.activeSelf) _conditions[CollisionZone.LeftHand] = true;
        if (!rightDectector.gameObject.activeSelf) _conditions[CollisionZone.RightHand] = true;
        if (!headDectector.gameObject.activeSelf) _conditions[CollisionZone.MainCamera] = true;
        
        //Debug.Log(_conditions[CollisionZone.LeftHand] + " " + _conditions[CollisionZone.RightHand] + " " + _conditions[CollisionZone.MainCamera]);
        
        if (!headDectector && !rightDectector && !leftDectector) throw new Exception("NO COLLISION BOXES ON WALL " + gameObject.name);
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
        else if (gameObject.transform.position.y + 10 < playerPos.position.y)
        {
            onWallFailed.Invoke(gameObject);
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
