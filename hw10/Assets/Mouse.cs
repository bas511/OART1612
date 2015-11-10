using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	public AudioSource alerted;
	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		foreach (GameObject cat in GameManager.catList) {
			Vector3 directionToCat = cat.transform.position - transform.position;
			float angle = Vector3.Angle (transform.forward, directionToCat);

			if (angle < 180) {
				Debug.Log ("NO1!");

				Ray mouseRay = new Ray (transform.position, directionToCat );
				RaycastHit mouseRayHitInfo;

				if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 100f)) {
					if (mouseRayHitInfo.collider.tag == "Cat") {
						alerted.Play();
						rbody.AddForce(-directionToCat.normalized * 1000f);
					}
				}
			}
		}
	}
}
