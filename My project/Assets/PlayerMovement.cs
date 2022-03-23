using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private CharacterController2D _controller;
	[SerializeField] private Rigidbody2D _rigidbody;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	[Range(1, 10)] public float rotCorrectSpeed = 2;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		
	}

	void FixedUpdate()
	{
		float rot = _rigidbody.rotation;

		// Debug.Log(rot);

		if (rot <= 0)
        {
			
			_rigidbody.rotation = rot / rotCorrectSpeed;
        }

		if (rot >= 0)
		{
			_rigidbody.rotation = rot / rotCorrectSpeed;
		}
        else
        {
			
        }

		// Move our character
		_controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
