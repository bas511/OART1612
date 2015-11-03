using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {

		Ray moveRay = new Ray(transform.position, transform.forward);
		Debug.DrawRay ( moveRay.origin, moveRay.direction * 100f, Color.blue );
		RaycastHit moveRayHit;

		if (Physics.Raycast(moveRay, out moveRayHit, 3f)) {
			Debug.Log ("HIT");
			float rando = Random.Range(0f, 1f);
			if (rando > 0.5f) {
				transform.Rotate(0f, 90f, 0f);
			} else {
				transform.Rotate(0f, -90f, 0f);
			}
		}

	rbody.velocity = (transform.forward * 5f + Physics.gravity);

	}
}
