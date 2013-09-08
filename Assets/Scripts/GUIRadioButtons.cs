using UnityEngine;
using System.Collections;

public class GUIRadioButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,90), "Game Mode");

		if(TheState._TheMode == TheState.GameMode.exposure){
			GUI.color = Color.magenta;	
		}
		else if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
			GUI.color = Color.gray;
		}
		if(GUI.Button(new Rect(20,40,80,20), "Exposure")) {
			TheState._TheMode = TheState.GameMode.exposure;
		}
		
		if(TheState._TheMode == TheState.GameMode.exposure){
			GUI.color = Color.gray;	
		}
		else if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
			GUI.color = Color.magenta;
		}
		if(GUI.Button(new Rect(20,70,80,20), "Rule of Thirds")) {
			TheState._TheMode = TheState.GameMode.ruleOfThirds;
		}
	}
	
}
