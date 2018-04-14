using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	struct ParsedInputs {
		public Vector2 move;
		public int moveCamera;
	} 
	ParsedInputs parsedInputs = new ParsedInputs{};
	
	struct Settings {
		public float camDistance;
		public Settings(bool doesNothing){
			camDistance = 8.0f;
		}
	} 
	private Settings settings = new Settings(true);

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
			parsedInputs.move.x = 1.0f;
		else if (Input.GetKey(KeyCode.S))
			parsedInputs.move.x = -1.0f;
		else
			parsedInputs.move.x = 0.0f;

		if (Input.GetKey(KeyCode.A))
			parsedInputs.move.y = 1.0f;
		else if (Input.GetKey(KeyCode.D))
			parsedInputs.move.y = -1.0f;
		else
			parsedInputs.move.y = 0.0f;

		if (Input.GetKeyDown(KeyCode.Q)) {
			parsedInputs.moveCamera = -1;
			Debug.Log("Q");
		} else if (Input.GetKeyDown(KeyCode.E))
			parsedInputs.moveCamera = 1;
		else 
			parsedInputs.moveCamera = 0;

		//Camera Controls
		if (parsedInputs.moveCamera == -1)
		{
			cam.Rotate(0.0f, 90.0f, 0.0f, Space.World);
			if (cam.localPosition.x < 0.0f) {
				Debug.Log("1");
				cam.localPosition = new Vector3(0.0f, cam.localPosition.y, settings.camDistance);
			} else if (cam.localPosition.x > 0.0f) {
				Debug.Log("2");
				cam.localPosition = new Vector3(0.0f, cam.localPosition.y, -settings.camDistance);
			} else if (cam.localPosition.z < 0.0f) {
				Debug.Log("3");
				cam.localPosition = new Vector3(-settings.camDistance, cam.localPosition.y, 0.0f);
			} else if (cam.localPosition.z > 0.0f) {
				Debug.Log("4");
				cam.localPosition = new Vector3(settings.camDistance, cam.localPosition.y, 0.0f);
			}
		}
	}

	void FixedUpdate() {
				
		//Movement
		Vector3 moveVector = new Vector3(
			parsedInputs.move.normalized.x * speed,
			rb.velocity.y,
			parsedInputs.move.normalized.y * speed
		);
		rb.AddForce(moveVector, ForceMode.VelocityChange);
		
		
		
	}

}
