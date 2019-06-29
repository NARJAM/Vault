using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerOnEnable : MonoBehaviour {
    public UnityEvent anyAction;
    public Image fillImage;
    public Text timerValue;
    public float maxTime;
    public float tempTime;

    public void OnEnable()
    {
        tempTime = 0;
        fillImage.fillAmount = 1f;
    }

    private void Update()
    {
        if (tempTime > maxTime)
        {
            anyAction.Invoke();
        }
        else {
            tempTime += Time.deltaTime;
            timerValue.text = Mathf.CeilToInt(maxTime - tempTime).ToString();
            fillImage.fillAmount = (maxTime - tempTime)/maxTime;
        }
    }
}
