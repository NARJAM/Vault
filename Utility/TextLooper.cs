using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLooper : MonoBehaviour {
    public float delayValue;
    public List<string> loopText;
    int currentIndex;
    Text thisText;

    float tempTime;

    private void Awake()
    {
        thisText = GetComponent<Text>();
    }

    void Enable () {
        tempTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        tempTime += Time.deltaTime;
        if (tempTime > delayValue) {
            tempTime = 0f;
            currentIndex++;
            if (currentIndex == loopText.Count) {
                currentIndex = 0;
            }
            thisText.text = loopText[currentIndex];
        }
	}
}
