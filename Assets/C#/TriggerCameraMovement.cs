using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraMovement : MonoBehaviour {

    //      1 UP
    // 4 LEFT    2 RIGHT
    //      3 DOWN

    public int direction = 0;
    public GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        if(collision.tag == "Player")
        {
            if (Player.GetComponent<Player>().wasDead)
            {
                Player.GetComponent<Player>().wasDead = false;
            } else
            {
                if (direction != 0)
                {
                    cam.GetComponent<CameraMovement>().MoveCamera(direction);
                }

            }
        }
    }
}
