using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {
	Animator anim;
	private Rigidbody rigidBody;
	private bool jump = false;
	[SerializeField] private float jumpForce = 100f;
    [SerializeField] private AudioClip sfxJump;
	[SerializeField] private AudioClip sfxDeath;
	private AudioSource audioSource;

	// Use this for initialization
	void Awake(){
	Assert.IsNotNull (sfxJump);
	Assert.IsNotNull (sfxDeath);

	}
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameManager.instance.GameOver&& GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {
				GameManager.instance.PlayerStartedGame ();
				anim.Play ("jump");
				audioSource.PlayOneShot (sfxJump);
				rigidBody.useGravity = true;
				jump = true;
			}
		}

	}
	void FixedUpdate()
	{
		
		if (jump == true) {
			jump = false;
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce (new Vector2 (0, 100f), ForceMode.Impulse);
		}
}
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "obstacle") {
			Debug.Log ("jai ho");
			rigidBody.AddForce (new Vector2 (-50, 20), ForceMode.Impulse);
			//rigidBody.detectCollisions = false;
			audioSource.PlayOneShot (sfxDeath);
			GameManager.instance.PlayerCollided ();

		}
	}
}

