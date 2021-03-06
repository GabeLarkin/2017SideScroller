﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpHeight = 7;
    public float deadZone = -3.5f;
    public bool canFly = false;
    public bool crippleJump = false;

    public Weapon currentWeapon;
    private List<Weapon> weapons = new List<Weapon>();

    new Rigidbody2D rigidbody;
    GM _GM;
    private int _Lives = 3;
    private Vector3 startingPosition;
    private Animator anim;
    private bool air;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start() {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator>();
        air = true;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        // Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (v.x != 0)
        {
            anim.SetBool("running", true);
        }
        else {
            anim.SetBool("running", false);
        }

        if (v.x > 0) {
            sr.flipX = false;
        } else if (v.x < 0) {
            sr.flipX = true;
        }


        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly)) {
            v.y = jumpHeight;
        }

        if (v.y != 0) {
            anim.SetBool("inAir", true);
        }
        else
        {
            anim.SetBool("inAir", false);
        }

        //Attack with a weapon if you have one
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }


            rigidbody.velocity = v;

        //Check for out
        if (transform.position.y < deadZone) {
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



    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }

    
    public void SetCurrentWeapon(Weapon w)
    {
        if (currentWeapon != null) {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = w;

        if (currentWeapon != null) {
            currentWeapon.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if(weapon != null)
        {
            weapon.GetPickedUp(this);
        }
    }

    //Player moves along with moving platforms
    private void OnCollisionExit2D(Collision2D collision)
    {
        air = true;
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
}
