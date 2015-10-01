using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class goldbergMain : MonoBehaviour {

	int phase = 0;
	public Transform firstBall;
	public Transform secondBall;
	public Transform thirdBall;
	public Transform fourthBall;
	public GameObject GameOver;
	public float camPanSpeedY1 = 10f;
	public float camPanSpeedX1 = 3f;
	public float camPanSpeedZ1 = .5f;
	float startTime;
	float wait1 = 3f;
	float wait2 = 22f;
	bool firstForceFlag = false;
	bool secondForceFlag = false;
	bool thirdForceFlag = false;
	Vector3 startPos = new Vector3(94.04f,2.71f,-93.8f); 
	Vector3 startAngles = new Vector3(0,321.97f,0); // placeholder so Unity can stfu
	Vector3 endPos = new Vector3(105.1f, 23.7f, -109.5f);
	Vector3 endAngles = new Vector3(33.84f, 329.1f, 0);
	// Use this for initialization
	void Start () {
		Rigidbody firstRB = firstBall.GetComponent<Rigidbody>();
		firstRB.AddForce(new Vector3(0,0,-500f));
	}
	
	// Update is called once per frame
	void Update () {
		if (phase == 0) {
			if (firstBall.position.z > -3) {
				float distX = Camera.main.transform.position.x - firstBall.position.x;
				float distZ = Camera.main.transform.position.z - firstBall.position.z;
				float camThetaXZ = Mathf.Atan(distX/distZ) ;
				Camera.main.transform.Rotate(0, camThetaXZ, 0);
				if (Camera.main.transform.eulerAngles.y >90) {
					Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, 90,0);
				}
			} else if (firstBall.position.z > -7) {
				// pan camera up and rotate down to reveal title
				Camera.main.transform.position += new Vector3 (-camPanSpeedX1 * Time.deltaTime , camPanSpeedY1 * Time.deltaTime,
				                                               camPanSpeedZ1 * Time.deltaTime);
				float distY = Camera.main.transform.position.y - firstBall.position.y;
				float distZ = Camera.main.transform.position.z - firstBall.position.z;
				float camThetaYZ = Mathf.Atan(distY/distZ); 
				Camera.main.transform.Rotate(-camThetaYZ,0,0);

				float distX = Camera.main.transform.position.x - firstBall.position.x;
				float camThetaXZ = Mathf.Atan(distX/distZ) ;
				Camera.main.transform.Rotate(0, camThetaXZ, 0);


				if (Camera.main.transform.eulerAngles.y >90) {
					Camera.main.transform.eulerAngles = new Vector3(Camera.main.transform.eulerAngles.x, 90,0);
				}
			}  /*
			if (Camera.main.transform.eulerAngles.y > 89)	{
				//Camera.main.transform.position += new Vector3 (-camPanSpeedX1 * Time.deltaTime , camPanSpeedY1 * Time.deltaTime, 0);
				float distY = Camera.main.transform.position.y - firstBall.position.y;
				float distZ = Camera.main.transform.position.z - firstBall.position.z;
				float camThetaYZ = Mathf.Atan(distY/distZ); // x distance from ball to cam is always 4 in this phase

				Camera.main.transform.Rotate(-camThetaYZ,0,0);
				float camX = Camera.main.transform.eulerAngles.x;
				Camera.main.transform.eulerAngles = new Vector3(camX, 90, 0);

			}
			*/
			if (firstBall.position.z < -17) {
				if (!firstForceFlag) {
					Rigidbody firstRB = firstBall.GetComponent<Rigidbody>();
					firstRB.AddForce(new Vector3(0,0,-1000f));
					firstForceFlag = true;
				}
				Camera.main.transform.position = new Vector3(-4f, 2.71f, firstBall.position.z);
				Camera.main.transform.eulerAngles = new Vector3(0f, 90f, 0f);
			}
			if (firstBall.position.z < -65f) {
				if (!secondForceFlag) {
					Rigidbody firstRB = firstBall.GetComponent<Rigidbody>();
					firstRB.AddForce(new Vector3(0,0,-200f));
					secondForceFlag = true;
				}
				Camera.main.transform.position += new Vector3(0, 25f * Time.deltaTime, 0f);
				phase = 1;
			}
		}
		else if (phase == 1) {
			Camera.main.transform.position = new Vector3(-3, 4, - 65);
			Camera.main.transform.eulerAngles = new Vector3(25, 145, 0);
			if (secondBall.transform.position.y < .4) {phase =2;}
		}
		else if (phase == 2) {
			Camera.main.transform.position = new Vector3 (secondBall.position.x, secondBall.position.y, 
			                                              secondBall.position.z - 5);
			Camera.main.transform.eulerAngles =  new Vector3(0, 0, 0);

			if (secondBall.transform.position.x > 6) {phase = 3 ;}
		}
		else if (phase == 3) {
			Camera.main.transform.position += new Vector3 (2f * Time.deltaTime, 0.175f * Time.deltaTime,
			                                               -.25f * Time.deltaTime);
			if (thirdBall.position.y > 6 && thirdBall.position.y < 54) {	
				Camera.main.transform.position = new Vector3(thirdBall.position.x + 3, thirdBall.position.y +4,
				                                             thirdBall.position.z + 5);
				Camera.main.transform.eulerAngles = new Vector3(30f, 210f, 0f);
			} else if (thirdBall.position.y >= 48.74) {
				Camera.main.transform.position = new Vector3(32.33f, 61.25f, -57.27f);
				Camera.main.transform.eulerAngles = new Vector3(12, 230f, 0f);
			}

			if (fourthBall.position.y < 45) {phase = 4;}

		}
		else if (phase == 4) {
				Camera.main.transform.position = new Vector3(fourthBall.position.x , fourthBall.position.y + 1 ,
				                                             fourthBall.position.z - 7 );
				Camera.main.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			if (fourthBall.position.x > 40) {
				Camera.main.transform.position += new Vector3( 0, 0, 5f);
				phase = 5;
			}
		}
		else if (phase == 5) {
			if (Camera.main.transform.position.x < 67) {
				Camera.main.transform.position += new Vector3 (1.5f *  Time.deltaTime, 0, -1.5f * 1.327f *Time.deltaTime);
			} else if (Camera.main.transform.position.x >= 67 &&  Camera.main.transform.eulerAngles.y < 41) {
				Camera.main.transform.Rotate(0,20f * Time.deltaTime, 0);
				Camera.main.transform.position += new Vector3 (0, 0.5f * Time.deltaTime, 0);
			} else if (Camera.main.transform.eulerAngles.y >= 41) {
				if (wait1 <= 0) {
					Camera.main.transform.position = new Vector3 (71f,2.53f, -84.2f);
					Camera.main.transform.eulerAngles = new Vector3 (0f,161f,0f);
					phase = 6;
				} else {
					wait1 -= Time.deltaTime;
				}
			}
		}
		else if (phase == 6) {

			if (Camera.main.transform.position.x < 85) {
				Camera.main.transform.position += new Vector3 (0.5f *  Time.deltaTime, 0, 0);
			} else  {
				if (!thirdForceFlag) {
					Camera.main.transform.position = startPos ; 
					Camera.main.transform.eulerAngles = startAngles;
					thirdForceFlag = true;
				}
			}
			if (!(Camera.main.transform.position.x < 85)) {
				Camera.main.transform.position += new Vector3 (11.1f * Time.deltaTime/3, 
				                                               20.99f * Time.deltaTime/3,
				                                               -15.7f * Time.deltaTime/3);
				Camera.main.transform.eulerAngles += new Vector3 (33.84f * Time.deltaTime/3, 
				                                               7.13f * Time.deltaTime/3, 0 );
				/* I FORGOT HOW TO LERP LOL
				 * float distance = Vector3.Distance(Camera.main.transform.position, startPos);
				float total = Vector3.Distance(startPos, endPos);
				float fracJourney = distance / total;
				Camera.main.transform.position = Vector3.Lerp(startPos, endPos, fracJourney);
				Camera.main.transform.eulerAngles = Vector3.Lerp(startAngles, endPos, fracJourney);
				*/

			}
			if (Camera.main.transform.position.x > 105.1) {
				Camera.main.transform.position = endPos;
				Camera.main.transform.eulerAngles = endAngles;

				phase = 7;
			}
		}
		else if (phase ==7) {
			if (wait2 <= 0) {
				GameOver.GetComponent<TextMesh>().text = "END.";
			} else {
				wait2 -= Time.deltaTime;
			}
		}
	}
}

