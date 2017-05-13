using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    Player player;
    public bool changeSpeed = false;
    public float speed = 5;
    public float lastforSeconds = 10;
    float timeStarted = 0;

	// Use this for initialization
	void Start () {
        player.speed = 5;
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
            player.changeSpeed = true;
            player.speed = 2;
            Invoke("ResetSpeed", 5.0f);
            timeStarted = Time.time;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update () {
		if(speed != 0 && speed + lastforSeconds < Time.time)
        {
            timeStarted = 0;
            player.changeSpeed = false;
        }
	}
    void ResetSpeed()
    {
        player.speed = 5;
    }

}
