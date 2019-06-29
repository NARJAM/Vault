using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoParent : MonoBehaviour {
    public Transform fakeParent;

    private void Update()
    {
        transform.position = fakeParent.transform.position;
    }
}
