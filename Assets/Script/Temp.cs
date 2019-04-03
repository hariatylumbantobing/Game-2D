using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	private SpriteRenderer spriteRenderer;
	public Animator animator; //animasi
	float horizontalMove = 0f;

	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> (); //animasi
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump")) {
			animator.SetBool ("IsJumping", true);
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump"))
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}
		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite)
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}
		animator.SetFloat ("Speed", Mathf.Abs (velocity.x) / maxSpeed); //animasi
		targetVelocity = move * maxSpeed;
	}
}
