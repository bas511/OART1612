using UnityEngine;
using System.Collections;

public class Wallmaker : MonoBehaviour {

	public GameObject wallPrefab;
	int count = 0;
	Vector3 rand;

	// Update is called once per frame
	void Update () {
		if (count < 30) {
			float randomDec = Random.Range(0.0f, 1.0f);
			int randomNumberX = Random.Range (-8, 8);
			int randomNumberZ = Random.Range (-8, 8);


			if (randomDec < 0.5f) {
				float x = randomNumberX * 2.5f;
				float z = randomNumberZ * 2.5f;
				GameObject wall = (GameObject) Instantiate (wallPrefab, new Vector3(x, 1.5f, z), Quaternion.Euler(0f, 0f,0f));

				count++;
			} else  {
				float x = randomNumberX * 2.5f;
				float z = randomNumberZ * 2.5f;
				GameObject wall = (GameObject) Instantiate (wallPrefab, new Vector3(x, 1.5f, z), Quaternion.Euler(0f, 90f,0f));
				count++;
			}

		}
	}
}
