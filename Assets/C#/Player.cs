using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //      1 UP
    // 4 LEFT    2 RIGHT
    //      3 DOWN
    //Ändert die Gravitation nach der dementsprechenden Nummer
    public int gDirection = 3;
    public Transform SpawnPoint;
    

	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        //Nimmt den Input und 
        InputDirector();
        GravityDirector();

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
    }

    void InputDirector()
    {
        //Einstellung der Gravitation
        if(Input.GetAxis("GHorizontalXB") < 0 | Input.GetAxisRaw("GHorizontal") < 0)
        {
            Debug.Log("GHorizontal kleiner als 0");
            gDirection = 4;
        }

        if(Input.GetAxis("GHorizontalXB") > 0 | Input.GetAxisRaw("GHorizontal") > 0)
        {
            Debug.Log("GHorizontal größer als 0");
            gDirection = 2;
        }

        if(Input.GetAxis("GVerticalXB") < 0 | Input.GetAxisRaw("GVertical") < 0)
        {
            gDirection = 1;
        }

        if(Input.GetAxis("GVerticalXB") > 0 | Input.GetAxisRaw("GVertical") > 0)
        {
            gDirection = 3;
        }

        //Wenn man an der Wand klebt darf man sich nach oben und unten bewegen
        if(gDirection == 2 | gDirection == 4)
        {
            if(Input.GetAxis("VerticalXB") < 0 | Input.GetAxisRaw("Vertical") < 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 0.5f);
            } else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 0);
            }

            if (Input.GetAxis("VerticalXB") > 0 | Input.GetAxisRaw("Vertical") > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -0.5f);

            }
        }

        //Ansonsten nach links und rechts auf dem boden
        if(gDirection == 1 | gDirection == 3)
        {
            if (Input.GetAxis("HorizontalXB") < 0 | Input.GetAxisRaw("Horizontal") < 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -0.5f);
            }

            if (Input.GetAxis("HorizontalXB") > 0 | Input.GetAxisRaw("Horizontal") > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 0.5f);

            }

        }
    }

    void GravityDirector()
    {
        switch (gDirection)
        {
            case 1:
                Physics2D.gravity = new Vector2(0, 13f);
                break;
            case 2:
                Physics2D.gravity = new Vector2(13f, 0);
                break;
            case 3:
                Physics2D.gravity = new Vector2(0, -13f);
                break;
            case 4:
                Physics2D.gravity = new Vector2(-13f, 0);
                break;
        }

    }

    //Wird verwendet für Room transisitions und checkpoint managment
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Triggerzone")
        {
            SpawnPoint.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (collision.tag == "badguy")
        {
            death();
        }
    }

    //Setzt die Position des checkpointes
    private void death() 
    {
        Instantiate(gameObject, SpawnPoint);
        Destroy(gameObject);
    }
}
