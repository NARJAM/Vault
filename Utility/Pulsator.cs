using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsator : MonoBehaviour {
    public float pulsatingSpeed;
    public float tempSpeed;
    public SpriteRenderer hand;
    public Sprite handA;
    public Sprite handB;
    public bool overRideToB;
    bool pulseToggle;

    private void OnEnable()
    {
        pulseToggle = false;
        hand.sprite = handA;
        StartCoroutine("PulsatorCor");
    }

    IEnumerator PulsatorCor() {
        while (true) {
            yield return new WaitForSeconds(pulsatingSpeed);
       
        }
    }

    public void StartOverride() {
        overRideToB = true;
        pulseToggle = true;
        hand.sprite = handB;
        tempSpeed = 0;
    }

    public void StopOverride() {
        overRideToB = false;
    }
    private void Update()
    {
        if (tempSpeed < pulsatingSpeed && !overRideToB)
        {
            tempSpeed += Time.deltaTime;
        }
        else if(tempSpeed > pulsatingSpeed && !overRideToB)
        {
            tempSpeed = 0;
            pulseToggle = !pulseToggle;

            if (pulseToggle)
            {
                hand.sprite = handB;
            }
            else
            {
                hand.sprite = handA;
            }
        }
    }

    private void OnDisable()
    {
        StopCoroutine("PulsatorCor");
    }
}
