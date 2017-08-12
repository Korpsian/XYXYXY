using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float rng1 = Random.Range(-5f, 5f);
        float rng2 = Random.Range(-5f, 5f);

        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * rng1);
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * rng2);

        StartCoroutine(DestroyOverTime());
	}


    IEnumerator DestroyOverTime()
    {
        float time = Random.Range(1, 3);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
