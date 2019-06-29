using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINode : MonoBehaviour
{
    public List<GameObject> objects2Enable;
    public List<GameObject> objects2Disable;

    public bool isToggle;
    public bool toggleCheck;
    public void GoNextNode()
    {

        if (!isToggle)  
        {
            for (int i = 0; i < objects2Enable.Count; i++)
            {
                objects2Enable[i].SetActive(true);
            }
            for (int i = 0; i < objects2Disable.Count; i++)
            {
                objects2Disable[i].SetActive(false);
            }
        }
        else
        {
            if (toggleCheck)
            {

                for (int i = 0; i < objects2Enable.Count; i++)
                {
                    objects2Enable[i].SetActive(true);
                }
                for (int i = 0; i < objects2Disable.Count; i++)
                {
                    objects2Disable[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < objects2Enable.Count; i++)
                {
                    objects2Enable[i].SetActive(false);
                }
                for (int i = 0; i < objects2Disable.Count; i++)
                {
                    objects2Disable[i].SetActive(true);
                }
            }

            toggleCheck = !toggleCheck;
        }
    }
}
