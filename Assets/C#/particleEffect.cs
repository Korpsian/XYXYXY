using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Start particleEffect");
        StartCoroutine(DestroyOverTime());
	}


    IEnumerator DestroyOverTime()
    {
        Debug.Log("In Enumerator");

        while(gameObject.GetComponent<SpriteRenderer>().color.a > 0)
        {
            Debug.Log("in While schleife");
            var color = gameObject.GetComponent<SpriteRenderer>().color;
            Color tmp = color;
            tmp.a = tmp.a - 5f;
            color = tmp;
            yield return new WaitForSeconds(0.2f);
            
        }

        yield return new WaitForSeconds(1f);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
