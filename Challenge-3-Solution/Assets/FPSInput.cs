using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

	// Instead of making these variables public, I'll make them private because
	// I don't want other scripts modifying their values. However, I still want to
	// see them in the Inspector window, so I'll use the [SerializeField] attribute
	[SerializeField]
	private float gravity, defaultSpeed, crouchSpeed, crouchAmount, sprintSpeed;

	// This represents the current speed, so it doesn't need to be publicly accessible or
	// visible in the inspector—it is here merely for this script to update the
	// CharacterController's movement via the Move method
	private float speed;

	private CharacterController _charController;
	
	void Start() {
		// I like to separate the declaration of the variable (see above) from
		// setting the initial value
		defaultSpeed = 6.0f;
		speed = defaultSpeed;
		gravity = -9.8f;
		crouchSpeed = 3.0f;
		sprintSpeed = 12.0f;
		crouchAmount = 1.0f;

		_charController = GetComponent<CharacterController>();
	}
	
	void Update() {
		// ////// Begin Prof. Fishburn's Additions to the Update method

		// 1. Incorporate sprint and crouch from Challenge 2
		Sprint();

		Crouch();
		
		// ////// End Prof. Fishburn's Additions

		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	// Refactoring my sprint and crouch code into their own methods
    // to make the code easier to read in Update
	void Sprint()
	{
		// Sprint
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = sprintSpeed;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = defaultSpeed;
		}
	}

	void Crouch()
	{
		// Crouch
		if (Input.GetKeyDown(KeyCode.C))
		{
			speed = crouchSpeed;
			Vector3 camPos = Camera.main.transform.position;
			Camera.main.transform.position = new Vector3(camPos.x, camPos.y - crouchAmount, camPos.z);
		}
		else if (Input.GetKeyUp(KeyCode.C))
		{
			speed = defaultSpeed;
			Vector3 camPos = Camera.main.transform.position;
			Camera.main.transform.position = new Vector3(camPos.x, camPos.y + crouchAmount, camPos.z);
		}
	}
}