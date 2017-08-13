using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    bool used = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!used)
        {
            used = true;
            Debug.Log("Open URL");
            Application.OpenURL("http://www.google.de");
        }

    }

}
