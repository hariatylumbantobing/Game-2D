using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	private SpriteRenderer spriteRenderer;
	private Animator animator; //animasi

	private GameObject player;
	private GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8, enemy9;
	public GameController gameController;
	private int count = 0;


	public AudioSource diamondSound;
	public AudioSource goldSound;
	public AudioSource keySound;



	// Use this for initialization
	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> (); //animasi
		player = GameObject.FindGameObjectWithTag("Player");
		enemy1 = GameObject.FindGameObjectWithTag ("Enemy1");
		enemy2 = GameObject.FindGameObjectWithTag ("Enemy2");
		enemy3 = GameObject.FindGameObjectWithTag ("Enemy3");
		enemy4 = GameObject.FindGameObjectWithTag ("Enemy4");
		enemy5 = GameObject.FindGameObjectWithTag ("Enemy5");
		enemy6 = GameObject.FindGameObjectWithTag ("Enemy6");
		enemy7 = GameObject.FindGameObjectWithTag ("Enemy7");
		enemy8 = GameObject.FindGameObjectWithTag ("Enemy8");
		enemy9 = GameObject.FindGameObjectWithTag ("Enemy9");
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;
		move.x = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && grounded) {
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
		animator.SetBool ("Grounded", grounded); //animasi
		animator.SetFloat ("Speed", Mathf.Abs (velocity.x) / maxSpeed); //animasi
		targetVelocity = move * maxSpeed;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Enemy1") || other.gameObject.CompareTag ("Enemy2") || other.gameObject.CompareTag ("Enemy3")
			|| other.gameObject.CompareTag ("Enemy4") || other.gameObject.CompareTag ("Enemy5") || other.gameObject.CompareTag ("Enemy6")
			|| other.gameObject.CompareTag ("Enemy5") || other.gameObject.CompareTag ("Enemy8") || other.gameObject.CompareTag ("Enemy9")){
			if (count == 0) {
				count++;
				animator.SetBool("Died", true);
				LoadLevel (4);
			}
		}

		if (other.gameObject.CompareTag ("Diamond")) {
			other.gameObject.SetActive (false);
			gameController.AddDiamond (1);
			diamondSound.Play ();
		}

		if (other.gameObject.CompareTag ("Sun")) {
			other.gameObject.SetActive (false);
			goldSound.Play ();
			gameController.AddGold (1);
		}

		if (other.gameObject.CompareTag ("Key1")) {
			other.gameObject.SetActive (false);
			keySound.Play ();
			enemy1.SetActive (false);
			enemy2.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Key2")) {
			other.gameObject.SetActive (false);
			keySound.Play ();
			enemy3.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Key3")) {
			other.gameObject.SetActive (false);
			keySound.Play ();
			enemy4.SetActive (false);
			enemy5.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Key4")) {
			other.gameObject.SetActive (false);
			keySound.Play ();
			enemy6.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Key5")) {
			other.gameObject.SetActive (false);
			enemy7.SetActive (false);
			enemy8.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Key6")) {
			other.gameObject.SetActive (false);
			keySound.Play ();
			enemy9.SetActive (false);
		}

		if (other.gameObject.CompareTag ("Victory")) {
			LoadLevel (2);
		}

		if (other.gameObject.CompareTag ("Victory1")) {
			LoadLevel (3);
		}

		if (other.gameObject.CompareTag ("End")) {
			LoadLevel (6);
		}
	}

	public void LoadLevel(int level)
	{
		Application.LoadLevel(level);
	}
}
