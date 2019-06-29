using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveFromAtoBOnEnable : MonoBehaviour {

    public Vector2 startPosition;
    public Vector2 endPosition;
    public float moveSpeed;

    RectTransform thisRect;

    private void Awake()
    {
        thisRect = GetComponent<RectTransform>();
    }

    private void OnEnable() { 
    StopCoroutine("MoveABCor");
    StartCoroutine("MoveABCor");
    }

    IEnumerator MoveABCor() {
        thisRect.anchoredPosition = startPosition;

        while (Vector2.Distance(thisRect.anchoredPosition, endPosition) >=0.02f) {
            thisRect.anchoredPosition = Vector2.Lerp(thisRect.anchoredPosition,endPosition, moveSpeed*Time.deltaTime);
            yield return null;
        }

        thisRect.anchoredPosition = endPosition;
    }
}
