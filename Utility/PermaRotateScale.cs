using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaRotateScale : MonoBehaviour {
    public float rotateSpeed;
    public float scaleSpeed;
    public float scaleMagnitude;
    Vector3 maxScale;
    Vector3 minScale;

    bool scaleToggle;

    private void Start()
    {
        minScale = transform.localScale;
        maxScale = minScale * scaleMagnitude;
    }
    private void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,Time.deltaTime*rotateSpeed);

        if (scaleToggle)
        {
            transform.localScale = Vector3.Lerp(transform.localScale,maxScale,Time.deltaTime*scaleSpeed);
        }
        else {
            transform.localScale = Vector3.Lerp(transform.localScale, minScale, Time.deltaTime * scaleSpeed);
        }

        if (maxScale.x - transform.localScale.x <= 0.02f || transform.localScale.x - minScale.x<=0.02f) {
            scaleToggle = !scaleToggle;
        }
    }
}
