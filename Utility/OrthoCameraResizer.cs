using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthoCameraResizer : MonoBehaviour {
    public Camera thisCam;

    public float rat1;
    public float rat2;
    public float size1;
    public float size2;

	// Use this for initialization
	void Update () {
        float theRat = ((float)Screen.width / (float)Screen.height);

        if (theRat > rat1)
        {
            thisCam.orthographicSize = size1;
        }
        else if (theRat < rat2)
        {
            thisCam.orthographicSize = size2;
        }
        else
        {
            thisCam.orthographicSize = size2 + (theRat - rat2) * (size1 - size2) / (rat1 - rat2);
        }
	}
	
}
