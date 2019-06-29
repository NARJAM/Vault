using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraJam : MonoBehaviour {
    public Transform target;
    public float cameraLerpSpeed = 4f;
    public Vector3 maxEndBounds;
    public Vector3 minEndBounds;

    void FixedUpdate () {
        float finalX;
        float finalY;
        float finalZ;
       
        float deltaX = target.position.x - transform.position.x;
        float deltaY = target.position.y - transform.position.y;
        float deltaZ = target.position.z - transform.position.z;

        if (deltaX > maxEndBounds.x)
        {
                finalX = target.position.x - maxEndBounds.x;
        }else if (deltaX < minEndBounds.x) {
                finalX = target.position.x - minEndBounds.x;
        }
        else {
            finalX = Mathf.Lerp(transform.position.x, target.position.x, Time.fixedDeltaTime * cameraLerpSpeed);
        }

        if (deltaY > maxEndBounds.y)
        {
            finalY = target.position.y - maxEndBounds.y;
        } else if (deltaY < minEndBounds.y) {
            finalY = target.position.y - minEndBounds.y;
        }
        else
        {
            finalY = Mathf.Lerp(transform.position.y, target.position.y, Time.fixedDeltaTime * cameraLerpSpeed);
        }

        if (deltaZ > maxEndBounds.z)
        {
            finalZ = target.position.z - maxEndBounds.z;
        } else if (deltaZ < minEndBounds.z) {
            finalZ = target.position.z - minEndBounds.z;
        }
        else
        {
            finalZ = Mathf.Lerp(transform.position.z, target.position.z, Time.fixedDeltaTime * cameraLerpSpeed);
        }

        transform.position = new Vector3(finalX,finalY,finalZ);
    }
}
