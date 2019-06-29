using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteLooper : MonoBehaviour {
    public List<Sprite> frames;

    public float frameRate;
    public float tempRate;
    int currentSpriteIndex = 0;
    Image thisImage;

    void OnEnable() {
        currentSpriteIndex = 0;
        thisImage.sprite = frames[0];
    }

    void Awake() {
        thisImage = GetComponent<Image>();
    }

	void Update () {
        if (tempRate > frameRate)
        {
            tempRate = 0f;
            currentSpriteIndex++;
            if (currentSpriteIndex == frames.Count) {
                currentSpriteIndex = 0;
            }
            thisImage.sprite = frames[currentSpriteIndex];
        }
        else {
            tempRate += Time.deltaTime;
        }
	}
}
