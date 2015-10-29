using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class interactionsNPC : MonoBehaviour {

	string[] teacherText = {"Mrs. Richardson: You don't have a paper to hand in? go talk to Mrs. Stiller" +
		" in room 306. She'll have some words for you.", "Mrs. Stiller: I can't believe you! Do you want to" +
		" repeat the 8th grade? You better look around for something to hand in...", "Hi, I'm based off Brandon's" +
		" real-life art teacher. I used to hate him, but now that he doesn't go here anymore...no, wait, I still " +
		"hate him. Run along now.", "Hope you studied. If you didn't you'll be dead in the watuhs", "One of my students has" +
		" an extra lab...he was saying he forgot his lunch money. He should be using lunch to study!", "I'm the bio teacher. Brandon" +
		" hates biology so he didn't give me any flavor text. Sorry."};
	string[] studentText = {"Hey, all this juveline delinquency is making me thirsty...I'll trade you a page of my report on Ben Franklin for a drink...",
		"Thanks, and remember to do your homework yourself next time...",
		"Go away, I'm studying for Mrs. Kapner's test 7th period!", 
		"Looking for a scoop? Mrs. Shek in room 303 usually knows what's up.",
		"Look, I can't help you out but I can tell you this: pay attention to all the blackboards. Good luck.",
		"CRAP! I forgot there was a test. Hey! Trade your calculator for my math homework?", 
		"Thanks! Now what was it... negative b plus or minus...",
		"Sorry...oops...Hey, I forgot my glasses. Did you happen to find a pair? I'll make it worth you while.", 
		"I appreciate it. Here, take my essay on Macbeth.", 
		"NOOOO I love ziti but I forgot my money...I'll do anything for some cash! Please help?",
		"Nice! Here, take my chemistry lab. Now, to make sure I'm first in line at lunch..."};
	string pressSpace = "Press Space to talk";
	public Text prompt;
	public Text dialogue;
	public Transform teacher1;
	public Transform teacher2;
	public Transform teacher3;
	public Transform teacher4;
	public Transform teacher5;
	public Transform teacher6;
	public Transform sketchyStudent;
	public Transform mathStudent;
	public Transform blindStudent;
	public Transform hungryStudent;
	public Transform nerd1;
	public Transform nerd2;
	public Transform nerd3;
	public backpack myItems;

	bool teacher1talking, teacher2talking, teacher3talking, teacher4talking, teacher5talking, teacher6talking, sketchyStudenttalking, mathStudenttalking, blindStudenttalking, hungryStudenttalking, nerd1talking, nerd2talking, nerd3talking;
	bool sketchTalked = false;
	bool mathTalked = false;
	bool blindTalked = false;
	bool hungryTalked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (myItems.hasPaper) {
			prompt.text = "You have something to hand in! Head to Mrs. Stiller in Room 306.";
		}

		if (Vector3.Distance(transform.position, teacher1.transform.position) < 1) {
			Debug.Log ("TEACHER1");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher1talking = true;
				dialogue.text = teacherText[0];
			}
			prompt.text = (teacher1talking) ? "" : pressSpace;

		} else if (Vector3.Distance(transform.position, teacher1.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher1.transform.position) < 2 &&
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher1.transform.position) > 2 && 
		           dialogue.text == teacherText[0]) {

			dialogue.text = "";
			teacher1talking = false;
		}

		if (Vector3.Distance(transform.position, teacher2.transform.position) < 1) {
			Debug.Log ("TEACHER2");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher2talking = true;
				if (!myItems.hasPaper) {
					dialogue.text = teacherText[1];
				}
				else {
					dialogue.text = "Well, this will do. Congratulations.";
					prompt.text = "YOU WIN";
				}
			}
			prompt.text = (teacher2talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, teacher2.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher2.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher2.transform.position) > 2 && 
		           dialogue.text == teacherText[1]) {
			
			dialogue.text = "";
			teacher2talking = false;
		}

		if (Vector3.Distance(transform.position, teacher3.transform.position) < 1) {
			Debug.Log ("teacher3");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher3talking = true;
				dialogue.text = teacherText[2];
			}
			prompt.text = (teacher3talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, teacher3.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher3.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher3.transform.position) > 2 && 
		           dialogue.text == teacherText[2]) {
			
			dialogue.text = "";
			teacher3talking = false;
		}

		if (Vector3.Distance(transform.position, teacher4.transform.position) < 1) {
			Debug.Log ("teacher4");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher4talking = true;
				dialogue.text = teacherText[3];
			}
			prompt.text = (teacher4talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, teacher4.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher4.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher4.transform.position) > 2 && 
		           dialogue.text == teacherText[3]) {
			
			dialogue.text = "";
			teacher4talking = false;
		}

		if (Vector3.Distance(transform.position, teacher5.transform.position) < 1) {
			Debug.Log ("teacher5");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher5talking = true;
				dialogue.text = teacherText[4];
			}
			prompt.text = (teacher5talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, teacher5.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher5.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher5.transform.position) > 2 && 
		           dialogue.text == teacherText[4]) {
			
			dialogue.text = "";
			teacher5talking = false;
		}

		if (Vector3.Distance(transform.position, teacher6.transform.position) < 1) {
			Debug.Log ("teacher6");
			if (Input.GetKeyDown(KeyCode.Space)) {
				teacher6talking = true;
				dialogue.text = teacherText[5];
			}
			prompt.text = (teacher6talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, teacher6.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, teacher6.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, teacher6.transform.position) > 2 && 
		           dialogue.text == teacherText[5]) {
			
			dialogue.text = "";
			teacher6talking = false;
		}

		// sketchykid
		if (Vector3.Distance(transform.position, sketchyStudent.transform.position) < 1) {
			Debug.Log ("sketchyStudent");
			if (Input.GetKeyDown(KeyCode.Space) && myItems.items["WATER BOTTLE x 1"]) {
				sketchyStudenttalking = true;
				dialogue.text = studentText[0];
				sketchTalked = true;
			}
			prompt.text = (sketchyStudenttalking) ? "" : pressSpace;
			if (sketchTalked) {
				prompt.text = "Press 'Q' to give this kid water.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["WATER BOTTLE x 1"] = false;
					myItems.items["PAGE 1*"] = true;
					sketchTalked = false;
					prompt.text = "";
					dialogue.text = studentText[1];
				}
			}
			
		} else if (Vector3.Distance(transform.position, sketchyStudent.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, sketchyStudent.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			if (sketchTalked) {
				prompt.text = "Press 'Q' to give this kid water.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["WATER BOTTLE x 1"] = false;
					myItems.items["PAGE 1*"] = true;
					sketchTalked = false;
					prompt.text = "";
					dialogue.text = studentText[1];
				}
			}
		} else if (Vector3.Distance(transform.position, sketchyStudent.transform.position) > 2 && 
		           (dialogue.text == studentText[0]) || (dialogue.text == studentText[1])) {
			
			dialogue.text = "";
			sketchyStudenttalking = false;
		}

		if (Vector3.Distance(transform.position, nerd1.transform.position) < 1) {
			Debug.Log ("nerd1");
			if (Input.GetKeyDown(KeyCode.Space)) {
				nerd1talking = true;
				dialogue.text = studentText[2];
			}
			prompt.text = (nerd1talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, nerd1.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, nerd1.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, nerd1.transform.position) > 2 && 
		           dialogue.text == studentText[2]) {
			
			dialogue.text = "";
			nerd1talking = false;
		}

		if (Vector3.Distance(transform.position, nerd2.transform.position) < 1) {
			Debug.Log ("nerd2");
			if (Input.GetKeyDown(KeyCode.Space)) {
				nerd2talking = true;
				dialogue.text = studentText[3];
			}
			prompt.text = (nerd2talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, nerd2.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, nerd2.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, nerd2.transform.position) > 2 && 
		           dialogue.text == studentText[3]) {
			
			dialogue.text = "";
			nerd2talking = false;
		}
		if (Vector3.Distance(transform.position, nerd3.transform.position) < 1) {
			Debug.Log ("nerd3");
			if (Input.GetKeyDown(KeyCode.Space)) {
				nerd3talking = true;
				dialogue.text = studentText[4];
			}
			prompt.text = (nerd3talking) ? "" : pressSpace;
			
		} else if (Vector3.Distance(transform.position, nerd3.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, nerd3.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			prompt.text = "";
		} else if (Vector3.Distance(transform.position, nerd3.transform.position) > 2 && 
		           dialogue.text == studentText[4]) {
			
			dialogue.text = "";
			nerd3talking = false;
		}

		// math student
		if (Vector3.Distance(transform.position, mathStudent.transform.position) < 1) {
			Debug.Log ("mathStudent");
			if (Input.GetKeyDown(KeyCode.Space) && myItems.items["CALCULATOR x 1"]) {
				mathStudenttalking = true;
				dialogue.text = studentText[5];
				mathTalked = true;
			}
			prompt.text = (mathStudenttalking) ? "" : pressSpace;
			if (mathTalked) {
				prompt.text = "Press 'Q' to give this kid your calculator.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["CALCULATOR x 1"] = false;
					myItems.items["PAGE 3*"] = true;
					mathTalked = false;
					prompt.text = "";
					dialogue.text = studentText[6];
				}
			}
			
		} else if (Vector3.Distance(transform.position, mathStudent.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, mathStudent.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			if (mathTalked) {
				prompt.text = "Press 'Q' to give this kid your calculator.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["CALCULATOR x 1"] = false;
					myItems.items["PAGE 3*"] = true;
					mathTalked = false;
					prompt.text = "";
					dialogue.text = studentText[6];
				}
			}
		} else if (Vector3.Distance(transform.position, mathStudent.transform.position) > 2 && 
		           (dialogue.text == studentText[5]) || (dialogue.text == studentText[6])) {
			
			dialogue.text = "";
			mathStudenttalking = false;
		}

		// blind student
		if (Vector3.Distance(transform.position, blindStudent.transform.position) < 1) {
			Debug.Log ("blindStudent");
			if (Input.GetKeyDown(KeyCode.Space) && myItems.items["GLASSES x 1"]) {
				blindStudenttalking = true;
				dialogue.text = studentText[7];
				blindTalked = true;
			}
			prompt.text = (blindStudenttalking) ? "" : pressSpace;
			if (blindTalked && myItems.items["GLASSES x 1"]) {
				prompt.text = "Press 'Q' to give this kid the glasses.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["GLASSES x 1"] = false;
					myItems.items["PAGE 4*"] = true;
					blindTalked = false;
					prompt.text = "";
					dialogue.text = studentText[8];
				}
			}
			
		} else if (Vector3.Distance(transform.position, blindStudent.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, blindStudent.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			if (blindTalked && myItems.items["GLASSES x 1"]) {
				prompt.text = "Press 'Q' to give this kid the glasses.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["GLASSES x 1"] = false;
					myItems.items["PAGE 4*"] = true;
					blindTalked = false;
					prompt.text = "";
					dialogue.text = studentText[8];
				}
			}
		} else if (Vector3.Distance(transform.position, blindStudent.transform.position) > 2 && 
		           (dialogue.text == studentText[7]) || (dialogue.text == studentText[8])) {
			
			dialogue.text = "";
			blindStudenttalking = false;
		}

		// hungry student
		if (Vector3.Distance(transform.position, hungryStudent.transform.position) < 1) {
			Debug.Log ("hungryStudent");
			if (Input.GetKeyDown(KeyCode.Space) && myItems.items["LUNCH MONEY x 1"]) {
				hungryStudenttalking = true;
				dialogue.text = studentText[9];
				hungryTalked = true;
			}
			prompt.text = (hungryStudenttalking) ? "" : pressSpace;
			if (hungryTalked) {
				prompt.text = "Press 'Q' to give this kid your lunch money.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["LUNCH MONEY x 1"] = false;
					myItems.items["PAGE 2*"] = true;
					hungryTalked = false;
					prompt.text = "";
					dialogue.text = studentText[10];
				}
			}
			
		} else if (Vector3.Distance(transform.position, hungryStudent.transform.position) > 1.5 &&
		           Vector3.Distance(transform.position, hungryStudent.transform.position) < 2 && 
		           prompt.text == pressSpace) {
			if (hungryTalked) {
				prompt.text = "Press 'Q' to give this kid your lunch money.";
				if (Input.GetKeyDown( KeyCode.Q) ) {
					myItems.items["LUNCH MONEY x 1"] = false;
					myItems.items["PAGE 2*"] = true;
					hungryTalked = false;
					prompt.text = "";
					dialogue.text = studentText[10];
				}
			}
		} else if (Vector3.Distance(transform.position, hungryStudent.transform.position) > 2 && 
		           (dialogue.text == studentText[9]) || (dialogue.text == studentText[10])) {
			
			dialogue.text = "";
			hungryStudenttalking = false;
		}
	}
}
