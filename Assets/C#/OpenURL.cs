using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    public string URL;
    bool used = false;

    Sprite State1;
    public Sprite State2;

    private void Start()
    {
        //Speichere den Ersten State ab
        State1 = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!used)
        {
            used = true;
            Debug.Log("Open URL");
            if(State2 != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = State2;
            }
            Application.OpenURL(URL);

        }

    }

}
