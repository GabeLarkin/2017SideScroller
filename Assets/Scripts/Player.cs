using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
    public float speed = 5;
    public float jumpHeight = 5;
    public float deadZone = -6;
    private int _Lives = 3;
    private Vector3 startingPosition;

    new Rigidbody2D rigidbody;
    GM _GM;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
		rigidbody = GetComponent<Rigidbody2D> ();
        _GM = FindObjectOfType<GM>();
	}
	
	// Update is called once per frame
	void fixedUpdate () {
        // Apply Movement
		float x = Input.GetAxisRaw ("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (Input.GetButtonDown("Jump"))
        {
            v.y = jumpHeight;
        }

        rigidbody.velocity = v;

        //Check for out
        if (transform.position.y < deadZone)
        {
            Debug.Log("Current Position " + transform.position.y + "is lower than " + deadZone);
            GetOut();
        }
		
	
	}
    public void GetOut()
    {
        _GM.SetLives(_GM.lives - 1);
        transform.position = startingPosition; 
        Debug.Log("You're Out");
    }
}
