using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaRotation : MonoBehaviour {
    public float rotationSpeed;
    public bool isUI;
    Vector3 rotateDirection;
    private void Awake()
    {
        if (isUI)
        {
            rotateDirection = Vector3.forward;
        }
        else {
            rotateDirection = Vector3.up;
        }
    }
    void Update () {
        transform.RotateAround(transform.position, rotateDirection, Time.unscaledDeltaTime * rotationSpeed);
    }
}
