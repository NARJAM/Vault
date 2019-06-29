using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingPongFadeImage : MonoBehaviour {
    public Color Color1;
    public Color Color2;
    public float ppSpeed;
    public bool ppState;
    public float scaleMag;

    Image targetSR;

    private void Awake()
    {
        targetSR = GetComponent<Image>();
    }

    void Update()
    {
        if (ppState)
        {
            if (Mathf.Abs(targetSR.color.a - Color1.a) >= 0.02f)
            {
                targetSR.color = Color.Lerp(targetSR.color, Color1, ppSpeed * Time.deltaTime);
            }
            else
            {
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

        transform.localScale = Vector3.one + (Vector3.one*(scaleMag-1f)*(targetSR.color.a - Color2.a))/(Color1.a - Color2.a);
    }
}
