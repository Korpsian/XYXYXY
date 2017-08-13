using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour {

    //Können Alle Texte definiert werden
    public GameObject[] Text;
    public bool oneAtATime = true;
    public float timeBetween = 1f;
    public float alphaSpeed = 0.1f;

    bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!used)
        {
            used = true;

            if (oneAtATime)
            {
                StartCoroutine(OneAtATime());
            } else
            {
                foreach (GameObject t in Text)
                {
                    StartCoroutine(CanvasGroupAlpha(t));
                }
            }
        }
    }

    IEnumerator OneAtATime()
    {
        foreach(GameObject t in Text)
        {
            StartCoroutine(CanvasGroupAlpha(t));
            yield return new WaitForSeconds(timeBetween);
        }

    }

    IEnumerator CanvasGroupAlpha(GameObject t)
    {
        var alpha = t.GetComponent<CanvasGroup>().alpha;

        while(alpha < 1)
        {
            alpha = alpha + 0.1f;
            yield return new WaitForSeconds(alphaSpeed);
        }
    }

}
