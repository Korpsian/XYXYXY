using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //      1 UP
    // 4 LEFT    2 RIGHT
    //      3 DOWN
    //Ändert die Gravitation nach der dementsprechenden Nummer
    public int gDirection = 3;

	// Use this for initialization
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        //Nimmt den Input und 
        InputDirector();
        GravityDirector();

    }

    void InputDirector()
    {

    }

    void GravityDirector()
    {
        switch (gDirection)
        {
            case 1:
                Physics2D.gravity = new Vector2(0, 13f);
                break;
            case 2:
                Physics2D.gravity = new Vector2(-13f, 0);
                break;
            case 3:
                Physics2D.gravity = new Vector2(0, -13f);
                break;
            case 4:
                Physics2D.gravity = new Vector2(13f, 0);
                break;
        }

    }


}
