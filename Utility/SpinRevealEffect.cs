using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRevealEffect : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;
    public RectTransform rotateBody;
    public RectTransform revealBody;
    public float restPositionX;
    public float revealPositionX;
    public bool revealState;

    public void ShowRevealMaster() {
        if (revealState)
        {
            Hide();
        }
        else {
            Show();
        }
        revealState = !revealState;
    }

    public void Show() {
        StopCoroutine("ShowCor");
        StopCoroutine("HideCor");
        StartCoroutine("ShowCor");
    }

    IEnumerator ShowCor() {
        Vector2 targetPosition = new Vector3(revealPositionX, revealBody.anchoredPosition.y);

        while (Mathf.Abs(revealBody.anchoredPosition.x - targetPosition.x) >= 0.2f) {
            //Debug.Log("ShowCor1 "  + revealBody.anchoredPosition.x);
            revealBody.anchoredPosition = Vector2.MoveTowards(revealBody.anchoredPosition, targetPosition,moveSpeed*Time.deltaTime);
            rotateBody.Rotate(Vector3.forward,rotateSpeed*Time.deltaTime);
            yield return null;
        }

        rotateBody.rotation = Quaternion.Euler(Vector3.zero);

        yield break;
    }

    IEnumerator HideCor() {
        Vector2 targetPosition = new Vector3(restPositionX, revealBody.anchoredPosition.y);

        while (Mathf.Abs(revealBody.anchoredPosition.x - targetPosition.x) >= 0.2f)
        {
            //Debug.Log("HideCor " + revealBody.anchoredPosition.x);
            revealBody.anchoredPosition = Vector2.MoveTowards(revealBody.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            rotateBody.Rotate(Vector3.forward, (-1f) * rotateSpeed * Time.deltaTime);
            yield return null;
        }
        rotateBody.rotation = Quaternion.Euler(Vector3.zero);

        yield break;
    }

    public void Hide() {
        StopCoroutine("ShowCor");
        StopCoroutine("HideCor");
        StartCoroutine("HideCor");
    }
}
