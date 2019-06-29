using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatEnable : MonoBehaviour {
    public float maxScale;
    public float beatSpeed;

    private void OnEnable()
    {
        StopCoroutine("Beater");
        StartCoroutine("Beater");
    }

    IEnumerator Beater() {
        transform.localScale = Vector3.one;
        while (Vector3.Distance(transform.localScale,Vector3.one*maxScale)>=0.02f) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one*maxScale,beatSpeed*Time.deltaTime);
            yield return null;
        }
        while (Vector3.Distance(transform.localScale, Vector3.one) >= 0.02f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, beatSpeed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
