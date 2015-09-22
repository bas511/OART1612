using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stubs : MonoBehaviour {

	string currentRoom = "Closet_Start"; // remembers our current location in world
	int guardsAlertLevel = 0; // don't piss them off yo
	bool showALevel = false;
	bool checkedElev = false;
	bool haveHelp = false;
	int escapeTries = 3;
	
	int DWallsChecked = 0;


	string[] alertLevelMessages = {"If there's anybody looking for you, they don't suspect a thing.", 
		"The people outside feel like something is a bit off ...", "The people in the hall are looking " +
		"over their shoulders a little more than they usually do...", "The guards are starting to talk to each " +
		"other...", "The guards are looking for an intruder!", "The guards know where you are...you " +
		"better hurry up!", "The guards have caught you! They knock you unconsicous. You wake up in a storage closet..."};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "You are currently in: ";

		// remove this in final version
		// textBuffer += "[" + guardsAlertLevel.ToString() + "] ";

		if (currentRoom == "Closet_Start" ) {
			textBuffer += "Some strange place.\n";

		}



		else if (currentRoom == "Closet_TryToLeave" || currentRoom == "Closet_LookAround" ||
		         currentRoom == "Closet_DarkLooking" || currentRoom == "Closet_DarkW" ||
		         currentRoom == "Closet_DarkS") {
			textBuffer += "the (VERY dimly lit) storage closet.\n";
		}
		else if (currentRoom == "Closet_LitLooking") {
			textBuffer += "the storage closet, but you can see clearly now.\n";
		}
		else if (currentRoom == "Opening_Closet") {
			textBuffer = "Opening the closet...";
		}
		else if (currentRoom == "Hallway") {
			textBuffer += "the hallway, just outside the closet you woke up in.";
		} 
		else if (currentRoom == "Elevators") {
			textBuffer += "the elevator bay.";
		}
		else if (currentRoom == "Stairs") {
			textBuffer += "the stairway";
		}
		else if (currentRoom == "Stairs_Up" || currentRoom == "Stairs_Up_Message" || currentRoom == "Stairs_Down") {
			textBuffer += "Stairway C";
		}
		else if (currentRoom == "Tiger_Hall" || currentRoom == "Tiger_Hall_Medium") {
			textBuffer += "Tiger Hall";
		}
		else if (currentRoom == "Lion_Hall" || currentRoom == "Conv_1" || currentRoom == "Conv_2" || currentRoom == "Conv_3") {
			textBuffer += "Lion Hall";
		}
		else if (currentRoom == "Penultimate" || currentRoom == "PenHelp") {
			textBuffer += "the end of Lion Hall";
		}
		else if (currentRoom == "DISAPPEAR") {
			textBuffer += "behind the 'DISAPPEAR' door";
		}
		else if (currentRoom == "ESCAPE") {
			textBuffer += "behind the 'ESCAPE' door";
		}


		if (showALevel) {
			textBuffer += "\n" + alertLevelMessages[guardsAlertLevel] + "\n";
		}
		if (guardsAlertLevel > 5) {
			textBuffer += "\n\nTry to be more careful next time! Pay attention to everything and think hard about your choices! (And be luckier.)";
			textBuffer += "\n\nPress Space to start again.";

			if (Input.GetKeyDown (KeyCode.Space)) { // reset game
				guardsAlertLevel = 0;
				currentRoom = "Closet_Start";
				showALevel = false;
				checkedElev = false;
				DWallsChecked = 0;
			}
		}
		else if (currentRoom == "Closet_Start") {
				textBuffer += "\nYou awake to find yourself in a storage room. You check your phone- " +
					"you have a new message from an anonymous number saying \" REMEMBER YOU ACTIONS VERY CAREFULLY! KEYS ARE THE KEY" +
					"\". \"Gee, that's a bit enigmatic\", you think. You're a bit dizzy but you're pretty " +
					"sure you should try to find your way out of wherever you are. Try to leave right away or " +
					"try to look around a bit?";
				textBuffer += "\n\npress [S] to stay in the room for a bit";
				textBuffer += "\npress [L] to try to exit the room";

				if (Input.GetKeyDown(KeyCode.L)) {
					currentRoom = "Closet_TryToLeave";
				} else if (Input.GetKeyDown(KeyCode.S)) {
					currentRoom = "Closet_LookAround";
				}

		} 
		else if (currentRoom == "Closet_TryToLeave") {
			textBuffer += "\nYou try to open the door but notice it's locked. As you try to turn " +
				"the handle, you hear some people outside the door. They might have heard you and " +
				"they're probably not friends of yours. You decide to (quietly) look around the " +
					"room for a key or something.";

			textBuffer += "\n\npress [S] to try to look around the room";
			if (Input.GetKeyDown(KeyCode.S)) {
				currentRoom = "Closet_LookAround";
				guardsAlertLevel++;
				showALevel = true;
			}
		} 
		else if (currentRoom == "Closet_LookAround") {
			if (guardsAlertLevel > 0) {
				textBuffer += "\nYou quickly realize the room";
			} else {
				textBuffer += "\n The room";
			}

			textBuffer += "'s dark but you you can figure out you're in a janitor's " +
				"closet. You feel around for a light switch and find one, but if there's anybody " +
					"outside they might figure out there's someone inside. Is it worth the risk " +
					"to make finding things a bit easier?";

			textBuffer += "\n\nPress [1] to turn on the light.";
			textBuffer += "\nPress [0] to leave the light off.";

			if (Input.GetKeyDown(KeyCode.Alpha1)) {
				currentRoom = "Closet_LitLooking";
				guardsAlertLevel++;
				showALevel = true;
			} else if (Input.GetKeyDown(KeyCode.Alpha0)) {
				currentRoom = "Closet_DarkLooking";
			}
		} 
		else if (currentRoom == "Closet_LitLooking") {
			textBuffer += "\nWith the light on, it's easy to find what you need. A set of keys is easily visible on " +
				"the east wall of the room. Fortunately, one reads \"STORAGE\". You grab the ring and continue.";
			textBuffer += "\n\nPress [E] to grab the keys on the east wall.";

			if (Input.GetKeyDown(KeyCode.E)) {
				currentRoom = "Opening_Closet";
			}
		}
		else if (currentRoom == "Closet_DarkLooking") {
			if( DWallsChecked == 0) { // first dialogue in this room
				textBuffer += "\nWith the room dark, it's pretty hard to look around. You can either feel around " +
					"on the east wall, the south wall, or the west wall.";
			}
			else  {
				textBuffer += "\nWhich wall do you want to check? Pick wisely, whoever's outside may start to get" +
					" suspicious if they hear too much movement in here.";
			}

			textBuffer += "\nPress[S] to check the on the south wall";
			textBuffer += "\nPress[E] to check the on the east wall";
			textBuffer += "\nPress[W] to check the on the west wall";


			if (Input.GetKeyDown (KeyCode.W)) {
				currentRoom = "Closet_DarkW";
			} else if (Input.GetKeyDown(KeyCode.S)) {
				currentRoom = "Closet_DarkS";
			} else if (Input.GetKeyDown(KeyCode.E)) {
				if (DWallsChecked == 2) {
					guardsAlertLevel++;
					showALevel = true;
				}
				currentRoom = "Opening_Closet";
			} 
		}
	
		else if (currentRoom == "Closet_DarkS") {
			textBuffer += "\n\nYou find a janitor's uniform! A useful disguise... if it wasn't two sizes too " +
				"big. Also, the name tag says 'Walter' and you don't really look like a Walter. It kinda " +
				"smells too. This is no good.";
			textBuffer += "\n\nPress Space to back to the middle of the room.";
			
			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "Closet_DarkLooking";
				DWallsChecked++;

			}
			
		}
		else if (currentRoom == "Closet_DarkW") {
			textBuffer += "\n\nYou find a rag and a mop. They might be useful later...or not. Because they're a " +
				"rag and a mop. Time to go back to the center of the room and try another wall.";
			textBuffer += "\n\nPress Space to back to the middle of the room.";
			
			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "Closet_DarkLooking";
				DWallsChecked++;
			}
			
		}
		else if (currentRoom == "Closet_DarkE") {
			textBuffer += "\n\nA ring of keys, and one of them is labeled \"Storage\"! ";
			if (DWallsChecked == 0) {
				textBuffer += "What luck! Keep that up and you'll get out of here with no issues at all!";
			} else if (DWallsChecked == 1) {
				textBuffer += "'Not too hard', you think to yourself as you take the ring off the hook.";
			} else if (DWallsChecked >= 2) {
				textBuffer += "Unlucky! All the noise you made looking around the entire room isn't good " +
					"the whole 'trying to stay undetected' deal. At least you can escape this room, though.";
			}

			textBuffer += "\n\nPress Space go to the door.";
			
			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "Opening_Closet";
				DWallsChecked++;
			}
			
		}
		else if (currentRoom == "Opening_Closet") { // placeholder for forking based on alert level
			showALevel = false;
			textBuffer = "You unlock the door...";
			if (guardsAlertLevel == 0) {
				textBuffer += "\nThere are what look like armed guards everywhere! Fortunately you've been careful and " +
					"quiet, so they haven't even picked up on you. Escaping will definitely be easier.";
			}
			if (guardsAlertLevel == 1) {
				textBuffer += "\nYou haven't been exactly silent, but the guards (who now definitely look unfriendly aren't " +
					"sure there's even someone else among them. Play it smart and you'll be out of here in no time.";
			}
			if (guardsAlertLevel >=2) {
				textBuffer += "\nYou've done a pretty good job of letting on you were in there! You have to be extra " +
					"careful, quick, or lucky from here on out unless you want to end up caught! If they find you, it's game over!";
			}
			textBuffer += "\n\nPress Space to open the door...";
			alertLevelMessages[1] = "The guards feel something is a bit off...";
			alertLevelMessages[2] = "The guards are looking over their shoulders a little more than they usually do...";
			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "Hallway";
				showALevel = true;
			}
		}
		else if (currentRoom == "Hallway") {
			textBuffer += "\nYou look left, and look right. At the end of the hallway to your left, it appears there's " +
				"a door the leads to a stairwell; to your right the hall leads to what looks like an area with elevators.";
			// continue here
			textBuffer += "\n\nPress [C] to head toward the stairway corridor";
			textBuffer += "\nPress [B] to head toward the elevator bay";

			if (Input.GetKeyDown(KeyCode.B)) {
				currentRoom = "Elevators";
			} else if (Input.GetKeyDown(KeyCode.C)) {
				currentRoom = "Stairs";

			}
		}
		else if (currentRoom == "Elevators") {
			textBuffer += "\nThe floor lights show...you're in the basement? Maybe the sign is wrong, but it says you're on " +
				"floor '-4'. You press the up arrow. \"DING.\" \"GOING UP.\" The obnoxiously loud voice alerted all the guards, " +
					"and the elevator is taking forever to come! You have to head back the other way.";
			textBuffer += "\n\nPress [C] to head back toward the stairway corridor.";

			if (Input.GetKeyDown(KeyCode.C)) {
				currentRoom = "Stairs";
				guardsAlertLevel++;
				checkedElev = true;
			}
		}
		else if (currentRoom == "Stairs") {
			if (!checkedElev) {
				textBuffer += "\nAt least it's quiet here. You look at the sign to see what floor you were on, and it says... 'Stairway " +
					"C, Floor -4'? Surely that must be a mistake. Or is it?";
			} else {
				textBuffer += "\nSeems to be quieter now. But that floor sign...it's on the wall in here too! 'Stairway C, Floor -4', " +
					"No mistaking it here.You might just be in the basement, but are you sure?";
			}
			textBuffer += "\n\nPress [U] to go continue up the stairway";
			textBuffer += "\nPress [D] to continue down the stairway";

			if (Input.GetKeyDown(KeyCode.D)) {
				currentRoom = "Stairs_Down";
			} else if (Input.GetKeyDown(KeyCode.U)) {
				currentRoom = "Stairs_Up_Message";
			}
		}
		else if (currentRoom == "Stairs_Down"){
			textBuffer += "\nYou continue down. To your dismay, every floor is locked, down to what you assume must be the lowest basement " +
				"level. Even going back to 'Floor -4' reveals that door's locked as well. Plus by now the guards have started to hear you on the " +
					"stairs-your only choice is to see if you'll have better luck on the higher floors.";
			textBuffer += "\n\nPress [U] to go up the stairs.";

			if (Input.GetKeyDown(KeyCode.U)) {
				currentRoom = "Stairs_Up_Message";
				guardsAlertLevel++;
			}
		}
		else if (currentRoom == "Stairs_Up_Message") {
			textBuffer += "\nOn your way climbing stairs, you receive a text a random number...the same number as the message you found when you woke " +
				"up in the storage closet. This one says, 'TAKE PRIDE IN YOUR NEXT CHOICE'. Who is that guy? Doesn't " +
					"he know you don't have unlimited texting? Anyway, you remember the weirdly phrased words and keep climbing.";

			textBuffer += "\n\nPress Space to continue upstairs.";

			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "Stairs_Up";
			}
		}
		else if (currentRoom == "Stairs_Up") {
			textBuffer += "\nYou finally reach an unlocked door...and it says Floor 1! Surely this is a good sign (no pun intended). Peeking out " +
				"the door, you see a 'TIGER HALL' to your left and a 'LION HALL' to your right. Weird names, you think. But maybe two weirds go " +
				"together?";

			textBuffer += "\n\nPress [L] to head towards TIGER HALL";
			textBuffer += "\n\nPress [R] to head towards LION HALL";

			if (Input.GetKeyDown (KeyCode.L)) {
				currentRoom = "Tiger_Hall_Mild";
			} else if (Input.GetKeyDown (KeyCode.R)) {
				currentRoom = "Lion_Hall";
			}
		}
		else if (currentRoom == "Tiger_Hall_Mild") {
			textBuffer += "\nAs you start walking, a non-uniformed guy walks up to you and says ominously: '\nHey, what's a group of sheep called?'" +
				" '\nA flock. Why?', you say. '\nNo reason...', he says as he leaves. Why would he say that. Was he trying to help?";

			textBuffer += "\n\nPress [L] to continue down Tiger Hall. Forget that weirdo";
			textBuffer += "\nPress [R] to head the other way to Lion Hall, that was a clue!";

			if (Input.GetKeyDown (KeyCode.L)) {
				currentRoom = "Tiger_Hall_Medium";
			} else if (Input.GetKeyDown (KeyCode.R)) {
				currentRoom = "Lion_Hall";
			}
		}
		else if (currentRoom == "Tiger_Hall_Medium") {
			textBuffer += "\nAfter a bit further, you find a another, shady-looking guy. 'That text- A group of lions is a pride, bud. You know " +
				"what a group of tigers is called?'";
			
			textBuffer += "\n\nPress [L] to find out.";
			textBuffer += "\nPress [R] to run the other way to Lion Hall, screw this guy!";
			
			if (Input.GetKeyDown (KeyCode.L)) {
				currentRoom = "Tiger_Hall_Caught";
			} else if (Input.GetKeyDown (KeyCode.R)) {
				currentRoom = "Lion_Hall";
				guardsAlertLevel++;

			}
		}
		else if (currentRoom == "Tiger_Hall_Caught") {
			textBuffer = "AN AMBUSH! Suddenly a dozen guards drop from the ceiling and render you unconscious. You wake up, what you guess is hours " +
				"later, in a storage closet...";
			
			textBuffer += "\n\nPress Space to restart your adventure";
			
			if (Input.GetKeyDown (KeyCode.Space)) { //reset game
				guardsAlertLevel = 0;
				currentRoom = "Closet_Start";
				showALevel = false;
				checkedElev = false;
				DWallsChecked = 0;
			}
		}
		else if (currentRoom == "Lion_Hall") {
			textBuffer += "\nAs you run, you come across a man locked in some sort of machine. 'Figured out the lion-pride thing, huh? Smart. Sorry I " +
				"couldn't have been more specific, they're probably intercepting those messages.'";

			textBuffer += "\n\n[SPACE]: Thanks. Who are you?";

			if (Input.GetKeyDown( KeyCode.Space)) {
				currentRoom = "Conv_1";
			} 
		}
		else if (currentRoom == "Conv_1") {
			textBuffer += "\n\"I designed this high-security building to act as a sort of an off-the-books prison. You know, for, um, 'special" +
				" interrogation techniques'.\"";
			
			textBuffer += "\n\n[SPACE]: What's with that first message you sent me? KEYS ARE THE KEY?";
			
			if (Input.GetKeyDown( KeyCode.Space)) {
				currentRoom = "Conv_2";
			} 
		}
		else if (currentRoom == "Conv_2") {
			textBuffer += "\n\"Oh, that? You'll find out pretty soon. I hope you've been keeping track of what you've been pressing though.\"";
			
			textBuffer += "\n\n[SPACE]: Why are you locked up?";
			
			if (Input.GetKeyDown( KeyCode.Space)) {
				currentRoom = "Conv_3";
			} 
		}
		else if (currentRoom == "Conv_3") {
			textBuffer += "\n\"Ever heard of irony? Well apparently the warden is a fan. But never mind why I'm here. Why don't you unlock me? " +
				"I can help you get out of here. We both have something to gain, no?\"";
			
			textBuffer += "\n\nPress [1] to accept help.";
			textBuffer += "\nPress [0] to leave him in the contraption.";
			
			if (Input.GetKeyDown( KeyCode.Alpha0)) {
				currentRoom = "Penultimate";
			} else if (Input.GetKeyDown( KeyCode.Alpha1)) {
				currentRoom = "Penultimate";
				haveHelp = true;
			}
		}
		else if (currentRoom == "Penultimate") {
			textBuffer += "\nYou're almost out of here, you can feel it! There are two doors with signs above them on opposite sides of the hall: " +
			"one sign reads 'DISAPPEAR', one says 'ESCAPE'. At this stage a mistake could mean game over!";

			textBuffer += "\n\nPress [D] to try to DISAPPEAR";
			textBuffer += "\nPress [E] to try to ESCAPE";
			if(haveHelp) {
				textBuffer += "\nPress [1] to ask your new friend for help";
			}
			if (Input.GetKeyDown( KeyCode.D)) {
				currentRoom = "DISAPPEAR";
			} else if (Input.GetKeyDown( KeyCode.E)) {
				currentRoom = "ESCAPE";
			} else if (Input.GetKeyDown( KeyCode.Alpha1)) {
				currentRoom = "PenHelp";
			}
		}
		else if (currentRoom == "PenHelp") {
			textBuffer += "\nYour friend says confidently, \"Man are you lucky I'm here...DISAPPEAR is what they call the break room for " +
				"the guards. ESCAPE is the exit. Hurry!\"";
			
			textBuffer += "\n\nPress[D] to try to DISAPPEAR";
			textBuffer += "\nPress [E] to try to ESCAPE";

			if (Input.GetKeyDown( KeyCode.D)) {
				currentRoom = "DISAPPEAR";
			} else if (Input.GetKeyDown( KeyCode.E)) {
				currentRoom = "ESCAPE";
			} 
		}
		else if (currentRoom == "DISAPPEAR") {
			textBuffer += "\n...The room is full of guards! They run after you full speed. Quick, head to ESCAPE! There isn't much time!";

			textBuffer += "\n\nPress [E] to head back to the door labeled 'ESCAPE'";

			if (Input.GetKeyDown(KeyCode.E)) {
				currentRoom = "ESCAPE";
				guardsAlertLevel = 5;
			}
		} 
		else if (currentRoom == "ESCAPE") {
			if (haveHelp) {
				textBuffer += "\nThe exit door as an electronic code lock. 'This is what that first text was all about!', says your friend.'";

				textBuffer += "\n\n[1]: Huh?";

				if (Input.GetKeyDown (KeyCode.Alpha1)) {
					currentRoom = "ESCAPE_HELP";
				}

			}
			else {
				textBuffer += "\nThis appears to be some sort of auxiliary escape door...but it has an electronic lock! Hopefully you've been " +
					"paying attention to what you've been doing! That first text may have been a clue!";
				textBuffer += "\n\nENTER CODE:";

				if (Input.anyKeyDown) {
					if (Input.GetKeyDown (KeyCode.S)) {
						currentRoom = "ESCAPE_S";
					} else { 
						escapeTries--;
						currentRoom = "ESCAPE_WRONG";
					}
				}
			}
		}
		else if (currentRoom == "ESCAPE_HELP") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";

			textBuffer += "\n\nENTER CODE:";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.S)) {
					currentRoom = "ESCAPE_S";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "ESCAPE_WRONG") {

			if (escapeTries > 0) {
				textBuffer += "\nINCORRECT. " + escapeTries.ToString() + " try/tries before alarm sounds.";
			} else {
				textBuffer += "\nINCORRECT. The machine blares an alarm, alerting all of the guards.";
				escapeTries = 3;
			}

			textBuffer += "\n\nPress Space to go back to trying to crack the code.";

			if (Input.GetKeyDown(KeyCode.Space)) {
				if (haveHelp) {
					currentRoom = "ESCAPE_HELP";
				} else {
					currentRoom = "ESCAPE";
				}
				if (escapeTries % 3 == 0) {guardsAlertLevel++;}
			}
		}
		else if (currentRoom == "ESCAPE_S") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";

			textBuffer += "\n\nENTER CODE: S ";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.E)) {
					currentRoom = "ESCAPE_E";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "ESCAPE_E") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";
			
			textBuffer += "\n\nENTER CODE: S E";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.C)) {
					currentRoom = "ESCAPE_C";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "ESCAPE_C") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";
			
			textBuffer += "\n\nENTER CODE: S E C";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.U)) {
					currentRoom = "ESCAPE_U";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "ESCAPE_U") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";
			
			textBuffer += "\n\nENTER CODE: S E C U";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.R)) {
					currentRoom = "ESCAPE_R";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "ESCAPE_R") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";
			
			textBuffer += "\n\nENTER CODE: S E C U R";
			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.E)) {
					currentRoom = "Leaving";
				} else { 
					escapeTries--;
					currentRoom = "ESCAPE_WRONG";
				}
			}
		}
		else if (currentRoom == "Leaving") {
			textBuffer += "\n'This is why I meant! Each of the letter keys you pressed to make a correct decision (like Lion instead of Tiger) on " +
				"your way out makes a plain, six-letter word. That's the code!' The pad stares you in the face:";
			
			textBuffer += "\n\nENTER CODE: S E C U R E. PASSWORD ACCEPTED";

			textBuffer += "\n\nPress Space to exit the building!";

			if (Input.GetKeyDown(KeyCode.Space)) {
				currentRoom = "End";
			}
		} 
		else if (currentRoom == "End") {
			textBuffer = "You have escaped, congratulations!";

			textBuffer += "\n\nPress R to restart.";

			if (Input.GetKeyDown(KeyCode.R)) { //reset game
				guardsAlertLevel = 0;
				currentRoom = "Closet_Start";
				showALevel = false;
				checkedElev = false;
				DWallsChecked = 0;
			}
		}

		GetComponent<Text>().text = textBuffer;
	}
}
