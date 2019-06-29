using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongFade : MonoBehaviour {
    public Color Color1;
    public Color Color2;
    public float ppSpeed;
    public bool ppState;

    SpriteRenderer targetSR;

    private void Awake()
    {
        targetSR = GetComponent<SpriteRenderer>();
    }

	void Update () {
        if (ppState)
        {
            if (Mathf.Abs(targetSR.color.a - Color1.a) >= 0.02f)
            {
                targetSR.color = Color.Lerp(targetSR.color, Color1, ppSpeed * Time.deltaTime);
            }
            else {
                ppState = !ppState;
            }      
        }
        else
        {
            if (Mathf.Abs(targetSR.color.a - Color2.a) >= 0.02f)
            {
                targetSR.color = Color.Lerp(targetSR.color, Color2, ppSpeed * Time.deltaTime);
            }
            else
            {
                ppState = !ppState;
            }
        }
	}
}
