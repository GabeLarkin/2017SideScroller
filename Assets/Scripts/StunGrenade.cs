using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable {

    public float blastRadius = 5;
    

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Explode();
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null && !isActive) {
            GetPickedUp(player);
        }
        if(isActive && player == null)
        {
            Explode();
        }
    }

    public void Throw() {
        isActive = true;
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5, 0);
        transform.parent = null;
    }

    public void GetPickedUp(Player player) {
       Debug.Log("Got picked up"); 
       isActive = true;
       collider2D.enabled = false;
       rigidbody2D.isKinematic = true;
       rigidbody2D.velocity = new Vector2(); 
       transform.parent = player.transform;
       transform.localScale = new Vector3(.2f, .2f);
       transform.localPosition = new Vector3(.2f, .2f); 

    }

      public void Explode() {
            // Get a reference to all enemies
            var enemies = FindObjectsOfType<Enemy>();

        // Loop through each enemy in the list
        foreach (var e in enemies){

            // Check if that enemy is within the blast radius
            if (Vector3.Distance(this.transform.position, e.transform.position) < 10)
            {
                // Set that enemy to NON-active
                Stun(e);
            }
        }
            // Set bomb to not active so the bomb disappears and cannot be picked up again
            gameObject.SetActive(false);
            
      }
    void Stun(Enemy e)
    {
        e.enabled = false;
    }
 }

