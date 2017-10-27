using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

	public GameObject BalloonContainer;
	public GameObject[] balloonList;
	public int maxBalloonsInScreen = 10;
	public int balloonPoolSize = 20;
	public int balloonsInScreen = 0;
	public Vector3 spawnArea;
	public Vector2 containerMinBounds;
	public Vector2 containerMaxBounds;

	public GObjectPool balloonPool;

	// Use this for initialization
	void Start () {
		if (balloonsInScreen < balloonList.Length)
			balloonsInScreen = balloonList.Length;
		spawnArea = BalloonContainer.transform.position;
		MeshRenderer renderer = BalloonContainer.GetComponents<MeshRenderer> ()[0];
		containerMinBounds.Set(renderer.bounds.min.x,renderer.bounds.min.z);
		containerMaxBounds.Set(renderer.bounds.max.x,renderer.bounds.max.z);

		//Instanciate all the balloons and create the pool
		createGameObjectPool();
	}
	
	// Update is called once per frame
	void Update () {

		if (balloonsInScreen >= maxBalloonsInScreen || balloonsInScreen == 0) {
			spawnBalloon ();
		}

	}

	void createGameObjectPool() {
		int balloonClass = 0;
		balloonPool = new GObjectPool ();
		for (int count = 0; count < balloonPoolSize; count++) {
			balloonClass = (int) Random.Range (0, balloonList.Length);
			balloonPool.AddGM (balloonList [balloonClass]);
//			balloonPool.Add (balloonList [balloonClass].GetComponent ("Balloon"));
		}

			
	}

	IEnumerable spawnBalloon() {

		GameObject borrowed;
		Balloon balloonScript;

		for (balloonsInScreen = 0; balloonsInScreen <= maxBalloonsInScreen; balloonsInScreen++) {

			borrowed = balloonPool.BorrowGM();
			balloonScript = (Balloon) borrowed.GetComponent ("Balloon");
			balloonScript.fire();

			yield return null;

		}

	}

}
