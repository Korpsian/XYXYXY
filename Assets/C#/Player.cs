using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //      1 UP
    // 4 LEFT    2 RIGHT
    //      3 DOWN
    //Ändert die Gravitation nach der dementsprechenden Nummer
    public int gDirection = 3;

    public bool ableToMove = true;
    public bool wasDead = true;
    int deathCount = 0;

    int spawnGDirection;
    Vector3 SpawnPoint;
    

	// Use this for initialization
	void Start () {
        SpawnPoint = transform.position;
        spawnGDirection = gDirection;
    }
	
	// Update is called once per frame
	void Update () {
        //Ist der Player erlaubt sich zu bewegen? 
        if (ableToMove)
        {
            InputDirector();
        }
        GravityDirector();

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
    }

    void InputDirector()
    {
        //Einstellung der Gravitation
        if(Input.GetAxis("GHorizontalXB") < 0 | Input.GetAxisRaw("GHorizontal") < 0)
        {
            gDirection = 4;
        }

        if(Input.GetAxis("GHorizontalXB") > 0 | Input.GetAxisRaw("GHorizontal") > 0)
        {
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

            var v = gameObject.GetComponent<Rigidbody2D>().velocity;

            if(Input.GetAxis("VerticalXB") == 0 | Input.GetAxisRaw("Vertical") == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
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

            if (Input.GetAxis("HorizontalXB") == 0 | Input.GetAxisRaw("Horizontal") == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            }


        }
    }

    void GravityDirector()
    {
        switch (gDirection)
        {
            case 1:
                Physics2D.gravity = new Vector2(0, 20f);
                break;
            case 2:
                Physics2D.gravity = new Vector2(20f, 0);
                break;
            case 3:
                Physics2D.gravity = new Vector2(0, -20f);
                break;
            case 4:
                Physics2D.gravity = new Vector2(-20f, 0);
                break;
        }

    }

    //Wird verwendet für Room transisitions und checkpoint managment
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Triggerzone")
        {
            SpawnPoint = new Vector3(transform.position.x, transform.position.y);
            spawnGDirection = gDirection;
        }
        if (collision.tag == "Badguy")
        {
            death();
        }
    }

    //Setzt die Position des checkpointes
    private void death() 
    {
        gDirection = spawnGDirection;
        wasDead = true;
        Instantiate(gameObject, SpawnPoint, Quaternion.identity);

        GameObject [] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject p in players)
        {
            if (p.name.Contains("(Clone)"))
            {
                p.GetComponent<Player>().deathCount++;
                p.name = "Player";
            }
        }
        Debug.Log(deathCount);

        Destroy(gameObject);
    }
}
