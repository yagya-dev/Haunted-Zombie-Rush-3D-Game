using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lets_Rock : Object1 {
	[SerializeField] private Vector3 topPosition;
	[SerializeField] private Vector3 bottomPosition;
	[SerializeField] private float speed;


	// Use this for initialization
	void Start () {
		StartCoroutine (Move (bottomPosition));
		
	}
	protected override void Update () {
		if(GameManager.instance.PlayerActive)
		base.Update ();
	}


	IEnumerator Move(Vector3 target)
	{
		while (Mathf.Abs ((target - transform.localPosition).y) > .20f) {
			Vector3 direction=target.y==topPosition.y ? Vector3.up:Vector3.down;
			transform.localPosition += direction * Time.deltaTime*speed;
			yield return null;

		}
		print ("Reached the Target");
		yield return  new WaitForSeconds (.5f);
		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;
		StartCoroutine (Move (newTarget));
	}

}
	// Update is called once per frame

