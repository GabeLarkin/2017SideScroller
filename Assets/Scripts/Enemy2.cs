using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    Player player;
    public bool crippleJump = false;
    public float lastforSeconds = 10;
    float timeStarted = 0;

	// Use this for initialization
	void Start () {
        player.jumpHeight = 7;
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!enabled)
        {
            return;
        }
        player = coll.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.crippleJump = true;
            player.jumpHeight = 3;
            timeStarted = Time.time;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update () {
        if (timeStarted != 0 && timeStarted + lastforSeconds == Time.time)
        {
            timeStarted = 0;
            player.crippleJump = false;
        }
    }
    

}
