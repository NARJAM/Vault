using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationJAM : MonoBehaviour {
    public List<Sprite> frames;
    SpriteRenderer thisSR;
    public float swapDelay;

    private void Awake()
    {
        thisSR = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        thisSR.sprite = frames[0];
        StopCoroutine("SpriteAnimCor");
        StartCoroutine("SpriteAnimCor");
    }

    IEnumerator SpriteAnimCor() {
        for (int i=0; i<frames.Count; i++) {
            thisSR.sprite = frames[i];
            yield return new WaitForSeconds(swapDelay);
        }
        yield break;
    }
}
