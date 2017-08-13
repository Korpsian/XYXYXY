using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMyText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<CanvasGroup>().alpha = 0f;
	}
}
