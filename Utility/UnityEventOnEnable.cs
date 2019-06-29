using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventOnEnable : MonoBehaviour {
    public UnityEvent anyAction;

    private void OnEnable()
    {
        if (anyAction != null)
        {
            anyAction.Invoke();
        }
    }
}
