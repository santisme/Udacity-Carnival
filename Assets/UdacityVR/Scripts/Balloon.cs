using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public float ascensionSpeed = 0.05f;
	public float topLimit = 80.0f;
	public bool fired = false;
	private Vector3 balloonPosition;
	private Quaternion balloonRotation;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private int direction = 0;
	public float maxWindForce = 0.04f;
	private float windForce;
	private float rotationSpeed = 0.0f;
	private float rotationAngle = 25.0f;
	private Quaternion targetRotation;
	private Transform ballonTransform;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		originalRotation = transform.rotation;
		ballonTransform = transform;
		resetBalloon ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (fired == true && ballonTransform.position.y < topLimit) {

			ballonTransform.position += Vector3.up * ascensionSpeed;
			if (direction == 1) {
				ballonTransform.position += Vector3.right * windForce;
				targetRotation = Quaternion.Euler(0, rotationAngle, 0);
			} else if (direction == 2) {
				ballonTransform.position += Vector3.left * windForce;
				targetRotation = Quaternion.Euler(0, -1 * rotationAngle, 0);
			}

			ballonTransform.rotation = Quaternion.Slerp(ballonTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

		} else {
			resetBalloon();
		}
	}

	void resetBalloon() {

		ballonTransform.position = originalPosition;
		ballonTransform.rotation = originalRotation;
		direction = Random.Range (0, 3);
		windForce = Random.Range (0.0f, maxWindForce);
		rotationAngle = Random.Range (5.0f, 25.0f);
		rotationSpeed = Random.Range (0.0f, 0.2f);
		fired = true;

	}

	public void fire() {

		fired = true;

	}
}
