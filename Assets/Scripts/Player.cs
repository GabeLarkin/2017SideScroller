﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
    public float speed = 5;
    public float jumpHeight = 5;
    public float deadZone = -6;
    public bool canFly = false;
    private int _Lives = 3;
    private Vector3 startingPosition;
    private Animator anim;
    private bool air;
    private SpriteRenderer sr;

    new Rigidbody2D rigidbody;
    GM _GM;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
		rigidbody = GetComponent<Rigidbody2D> ();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        air = true;
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Apply Movement
		float x = Input.GetAxisRaw ("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if(v.x) != 0){
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }

        if(v.x > 0){
            sr.flipX = false;
        } else if (v.x < 0){
            sr.flipX = true;
        }


        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly)){
            v.y = jumpHeight;
        }

        if(v.y != 0){
            anim.SetBool("inAir", true);
        } else if (v.x < 0) {
            sr.flipX = true;
        }

        rigidbody.velocity = v;

        //Check for out
        if (transform.position.y < deadZone){
            Debug.Log("Current Position " + transform.position.y + "is lower than " + deadZone);
            GetOut();
        }
		
	
	}
    public void GetOut()
    {
        _GM.SetLives(_GM._Lives - 1);
        transform.position = startingPosition; 
        Debug.Log("You're Out");
    }
}
