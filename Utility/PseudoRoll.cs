using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoRoll : MonoBehaviour {
    Rigidbody directorRB;
    public float rotationSens = 1f;

    Vector3 lastFramePos;
    private void Awake()
    {
        directorRB = transform.parent.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        lastFramePos = transform.position;
    }
    Vector3 currentFamePos;
    Vector3 pseudoVelocity;
    Vector3 endAxis;

    void Update () {
        currentFamePos = transform.position;

        pseudoVelocity = (currentFamePos - lastFramePos)/Time.deltaTime;

        if (pseudoVelocity.magnitude == 0f) {
            return;
        }

        float rotationMag = pseudoVelocity.magnitude;

        endAxis = Vector3.Cross(pseudoVelocity, Vector3.down).normalized;
        transform.RotateAround(transform.position,endAxis,rotationSens*Time.deltaTime*rotationMag);
        lastFramePos = transform.position;
	}
}
