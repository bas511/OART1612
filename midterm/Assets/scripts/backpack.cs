using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class backpack : MonoBehaviour {

	public Dictionary<string, bool> items = new Dictionary<string, bool>();
	public Dictionary<string, string> desc = new Dictionary<string, string>();
	public bool hasPaper = false;
	//public Dictionary<string, string> desc = new Dictionary<string, bool>();

	// Use this for initialization
	void Start () {
		items["WATER BOTTLE x 1"] = true;
		items["CALCULATOR x 1"] = true;
		items["LUNCH MONEY x 1"] = true;
		items["GLASSES x 1"] = false;
		items["PAGE 1*"] = false;
		items["PAGE 2*"] = false;
		items["PAGE 3*"] = false;
		items["PAGE 4*"] = false;
		items["PAGE 5*"] = false;
	}
	
	// Update is called once per frame
	void Update () {
		hasPaper = (items["PAGE 1*"] && items["PAGE 2*"] && items["PAGE 3*"] && items["PAGE 4*"] && items["PAGE 5*"]);
	}

}
