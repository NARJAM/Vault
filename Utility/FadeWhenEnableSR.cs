using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWhenEnableSR : MonoBehaviour {
    public float fadeSpeed;
    public Color initialAlpa;
    SpriteRenderer thisSR;
    private void Awake()
    {
        thisSR = GetComponent<SpriteRenderer>();
        initialAlpa = thisSR.color;
    }

    private void OnEnable()
    {
        StopCoroutine("FadeIN");
        StartCoroutine("FadeIN");
    }

    IEnumerator FadeIN() {
        while (Mathf.Abs(thisSR.color.a-initialAlpa.a)>=0.02f) {

            thisSR.color = Color.Lerp(thisSR.color,initialAlpa,fadeSpeed*Time.deltaTime);
            yield return null;
        }
    }
}
