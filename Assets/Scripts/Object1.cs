using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1 : MonoBehaviour {
	[SerializeField] private float objectSpeed=1;   
	[SerializeField] private float resetPosition = 66f;
	[SerializeField] private float startPosition = -2.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (!GameManager.instance.GameOver) {
			transform.Translate (Vector3.right * (objectSpeed * Time.deltaTime));
			if (transform.localPosition.x >= resetPosition) {
				Vector3 newPos = new  Vector3 (startPosition, transform.localPosition.y, transform.localPosition.z);
				transform.position = newPos;
			}
		}
	}
}