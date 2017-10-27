using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GObjectPool {

	private List<GameObject> objectPool;
	private bool isFull = false;
	private bool isEmpty = true;
	private int objectCount = 0;
	private int lastAvailableObjectNumber = 0;

	public GObjectPool(int count) {

		objectPool = new List<GameObject> ();
		objectPool.Capacity = count;

	}

	public GObjectPool() {
		
		objectPool = new List<GameObject> ();

	}

	public void AddGM(GameObject gm) {

		isEmpty = false;
//		objectPool.Add(GameObject.Instantiate<GameObject>(Resources.Load(gm.name)));
		objectPool.Add(GameObject.Instantiate<GameObject>(gm));
		objectCount++;
		lastAvailableObjectNumber++;

	}

	public GameObject BorrowGM() {

		if (IsEmpty() == false) {

			lastAvailableObjectNumber--;
			return objectPool [lastAvailableObjectNumber+1];

		}

		return null;

	}

	public bool IsEmpty() {

		bool answer = false;
		if (lastAvailableObjectNumber == 0)
			answer = true;

		return answer;

	}

	public bool IsFull() {

		bool answer = false;
		if (lastAvailableObjectNumber == objectCount)
			answer = true;

		return answer;

	}

}
