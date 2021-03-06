﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {


    //      1 UP
    // 4 LEFT    2 RIGHT
    //      3 DOWN

        //Bewegung ist gerade im gange
    bool activeMoving = false;

    public void MoveCamera(int direction)
    {
        Vector3 newPos = transform.position;

        //Wenn keine Aktive bewegung vorhanden ist, führe eine bewegung aus
        if (!activeMoving)
        {
            activeMoving = true;
            //Stoppe die Zeit
            Time.timeScale = 0.1f;

            switch (direction)
        {

            case 1:
                newPos.y = newPos.y + 1.28f;
                StartCoroutine(SlowCameraMovement(newPos));
                break;
            case 2:
                newPos.x = newPos.x + 1.28f;
                StartCoroutine(SlowCameraMovement(newPos));
                break;
            case 3:
                newPos.y = newPos.y - 1.28f;
                StartCoroutine(SlowCameraMovement(newPos));
                break;
            case 4:
                newPos.x = newPos.x - 1.28f;
                StartCoroutine(SlowCameraMovement(newPos));
                break;
        }

        }

    }

    IEnumerator SlowCameraMovement(Vector3 newPos)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Player.GetComponent<Player>().ableToMove = false;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);


        int yy = 0;
        //Während die Y Positionen nicht gleich sind, wiederholen diesen Step bis sie sind
        while (transform.position.y != newPos.y)
        {

            if (transform.position.y < newPos.y)
            {
                if(yy == 2)
                {
                    break;
                } else
                {
                    yy = 1;
                    transform.position = new Vector3(transform.position.x, CutMirDenShit(transform.position.y + 0.01f), transform.position.z);
                }
            }
            else if (transform.position.y > newPos.y)
            {
                if(yy == 1)
                {
                    break;
                } else
                {
                    yy = 2;
                    transform.position = new Vector3(transform.position.x, CutMirDenShit(transform.position.y - 0.01f), transform.position.z);
                }
            }
            yield return new WaitForSeconds(0.0001f);
        }

        int xx = 0;
        //Während die X Positionen nicht gleich sind, wiederholen diesen Step bis sie sind
        while (transform.position.x != newPos.x)
        {
            if (transform.position.x < newPos.x)
            {
                if(xx == 2)
                {
                    break;
                } else
                {
                    xx = 1;
                    transform.position = new Vector3(CutMirDenShit(transform.position.x + 0.01f), transform.position.y, transform.position.z);
                }
            }
            else if (transform.position.x > newPos.x)
            {
                if(xx == 1)
                {
                    break;
                } else
                {
                    xx = 2;
                    transform.position = new Vector3(CutMirDenShit(transform.position.x - 0.01f), transform.position.y, transform.position.z);
                }
            }
            yield return new WaitForSeconds(0.0001f);
        }
        Time.timeScale = 1;

        Player.GetComponent<Player>().ableToMove = true;
        yield return new WaitForSeconds(0.5f);
        activeMoving = false;
    }

    float CutMirDenShit(float derShit)
    {
        string stringShit = derShit.ToString("#.00");
        float neuerShit = float.Parse(stringShit);

        return neuerShit;
    }
}
