using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermaLookDown : MonoBehaviour {
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(Vector3.right*90f);
    }
}
