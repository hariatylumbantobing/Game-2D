using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {
	
	public float minGroundNormalY = .65f; //horizontal move
	public float gravityModifier = 1f;
	protected Vector2 targetVelocity; //horizontal move
	protected bool grounded; //Player Controller
	protected bool died; //Player Controller
	protected Vector2 groundNormal; //horizontal move
	protected Rigidbody2D rb2d;
	protected Vector2 velocity;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16]; //hit detector
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16); //hit detector
	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		targetVelocity = Vector2.zero; //horizontal move
		ComputeVelocity (); //Player Controller
	}

	//Player Controller
	protected virtual void ComputeVelocity()
	{
	}

	void FixedUpdate()
	{
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		velocity.x = targetVelocity.x; //horizontal move
		grounded = false; //Player Controller
		died = false;
		Vector2 deltaPosition = velocity * Time.deltaTime;
		Vector2 moveAlongGround = new Vector2 (groundNormal.y, -
			groundNormal.x); //horizontal move
		Vector2 move = moveAlongGround * deltaPosition.x; //horizontal move
		Movement (move, false); //horizontal move
		move = Vector2.up * deltaPosition.y;
		Movement (move, true);
	}

	void Movement(Vector2 move, bool yMovement)
	{
		float distance = move.magnitude;
		if (distance > minMoveDistance)
		{
			int count = rb2d.Cast (move, hitBuffer, distance + shellRadius); //hit detector
			hitBufferList.Clear (); //hit detector
			//hit detector
			for (int i = 0; i < count; i++) {
				hitBufferList.Add (hitBuffer [i]);
			}
			//If horizontal move
			for (int i = 0; i < hitBufferList.Count; i++)
			{
				Vector2 currentNormal = hitBufferList [i].normal;
				if (currentNormal.y > minGroundNormalY)
				{
					grounded = true; //Player Controller
					if (yMovement)
					{
						groundNormal = currentNormal;
						currentNormal.x = 0;
					}
				}
				float projection = Vector2.Dot (velocity, currentNormal); //Player Controller
				//If Player Controller
				if (projection < 0)
				{
					velocity = velocity - projection * currentNormal;
				}
				float modifiedDistance = hitBufferList [i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}
		}
		rb2d.position = rb2d.position + move.normalized * distance;
	}
}