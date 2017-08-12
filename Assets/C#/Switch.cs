using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    //Wenn toggle false ist, muss man sich auf dem switch befinden damit er an bleibt
    [Tooltip ("Ein und ausschalten des Buttons ist möglich")]
    public bool toggle = false;
    [Tooltip ("Normales Verhalten: Öffnen von Barriere bei ersten Kontakt. Umdrehen der Funktionsweise")]
    public bool reverse = false;
    bool used = false;

    Sprite State1;
    public Sprite State2;

    //Barriere zum aus/anschalten (Sollte eine Gruppe sein)
    public GameObject Barrier;

    private void Start()
    {
        //Speichere den Ersten State ab
        State1 = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    //Bei kollision mit dem Switch 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toggle)
        {
            if(!used)
            {
                used = true;
                if (reverse)
                {
                    CloseBarrier();
                } else
                {
                    OpenBarrier();
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = State2;
            } else if(used)
            {
                used = false;
                if (reverse)
                {
                    OpenBarrier();
                } else
                {
                    CloseBarrier();
                }

                gameObject.GetComponent<SpriteRenderer>().sprite = State1;
            }


        } else if (!toggle)
        {
            if (!used)
            {
                used = true;
                OpenBarrier();
                gameObject.GetComponent<SpriteRenderer>().sprite = State2;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    void OpenBarrier()
    {
        Barrier.SetActive(false);
    }

    void CloseBarrier()
    {
        Barrier.SetActive(true);
    }

}
