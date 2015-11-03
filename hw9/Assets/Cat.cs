using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	public AudioSource found;
	public AudioSource caught;
	public Transform mouse;
	Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		if (mouse) {
			Vector3 directionToMouse = mouse.transform.position - transform.position;
			float angleToMouse = Vector3.Angle(directionToMouse, transform.forward);

			if (angleToMouse < 90f) {
				Ray catRay = new Ray (transform.position, directionToMouse);
				RaycastHit catRayHitInfo;

				if (Physics.Raycast(catRay, out catRayHitInfo, 100f)) {
					if (catRayHitInfo.collider.tag == "Mouse") {
						if (catRayHitInfo.distance < 1 ) {
							caught.Play();
							Destroy(mouse.gameObject);
						} else {
							found.Play();
							rbody.AddForce(directionToMouse.normalized * 1000f);
						}
					}
				}
			}
		}
	}
}
