using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	struct ParsedInputs {
		float up,
			down,
			left,
			right;
		int moveCamera;
	}
	ParsedInputs parsedInputs = new ParsedInputs{};
	
	//Stats
	public float health = 100.0f,
		speed = 10.0f;

	private Rigidbody rb;
	private Transform cam;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
		cam = GameObject.Find("Main Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Pull inputs
		if (Input.GetKey(KeyCode.W))
			parsedInputs.up = 1.0f;
		else if (Input.GetKey(KeyCode.S))
			parsedInputs.down = -1.0f;
		else
			parsedInputs.x = 0.0f;

		if (Input.GetKey(KeyCode.A))
			parsedInputs.y = 1.0f;
		else if (Input.GetKey(KeyCode.D))
			parsedInputs.y = -1.0f;
		else
			parsedInputs.y = 0.0f;

		if (Input.GetKeyDown(KeyCode.Q))
			;
	}

	void FixedUpdate() {
		//Movement
		Vector3 moveVector = new Vector3(
			parsedInputs.normalized.x * speed,
			rb.velocity.y,
			parsedInputs.normalized.y * speed
		);
		rb.AddForce(moveVector, ForceMode.VelocityChange);
		

		
	}

}
