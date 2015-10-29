using UnityEngine;
using System.Collections;

public class pathmaker : MonoBehaviour {

	int counter = 0;
	public Transform floorPrefab;
	public Transform pathmakerPrefab;
	Vector3 angles;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter < 50) {
			float rand = Random.Range(0f, 1f);
			if (rand < .25f) {
				transform.Rotate(new Vector3(0f, 90f, 0f));
			}
			else if (rand < .5f) {
					transform.Rotate (new Vector3(0, -90f, 0f));
			}
			else if ( rand > .5f && rand < .85f) {
				angles = new Vector3((rand * 5f - 2.75f)* 10f ,0f,(rand * 5f - 2.5f)* 10f);
				Instantiate(pathmakerPrefab, transform.position, transform.rotation);
			}
			else if (rand > .85f) {
				Instantiate(pathmakerPrefab, transform.position, transform.rotation);
			}



			Instantiate(floorPrefab, transform.position, Quaternion.Euler(transform.eulerAngles - angles));
			transform.Translate(0f, 0f, 5f);
			counter++;
		} else {
			Destroy(this.gameObject);
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel("scene1");
		}
	}
}
