using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int health = 100;
	new RigidBody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<RigidBody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		rigidbody.velocity = new Vector2 (x, 0);
	
	}
}
