using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBase : MonoBehaviour
{

    public event Action<GameObject> onPassedSetLimit;
    public float maxDistance;
    public Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkPassedDistance();
    }

    private void checkPassedDistance()
    {
        if (maxDistance <= Vector3.Distance(startingPosition, transform.position))
        {
            onPassedSetLimit?.Invoke(gameObject);
        }
    }
}
