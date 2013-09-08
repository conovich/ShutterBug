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
		GUI.skin.label.fontSize = 15;
		GUI.Box(new Rect(10,10,200,150), "Game Mode");

		if(TheState._TheMode == TheState.GameMode.exposure){
			GUI.color = Color.magenta;	
		}
		else if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
			GUI.color = Color.gray;
		}
		if(GUI.Button(new Rect(20,40,180,30), "Exposure")) {
			TheState._TheMode = TheState.GameMode.exposure;
		}
		
		if(TheState._TheMode == TheState.GameMode.exposure){
			GUI.color = Color.gray;	
		}
		else if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
			GUI.color = Color.magenta;
		}
		if(GUI.Button(new Rect(20,80,180,30), "Rule of Thirds")) {
			TheState._TheMode = TheState.GameMode.ruleOfThirds;
		}
		
		GUI.color = Color.gray;	
		if(GUI.Button(new Rect(20,120,180,30), "Start Again!")) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
		
		if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
		
			float xCoord = 0.0f;
			float yCoord = 0.0f;
			float half = 0.5f;
			float third = 1.0f/3.0f;
			float twoThirds = 2.0f/3.0f;
			for (int i = 0; i < 3; i++){
				for (int j = 0; j < 3; j++){
					if (i == 0){
						xCoord = half*third*Screen.width;
					}
					else if (i == 1){
						xCoord = half*third*Screen.width + third*Screen.width;
					}
					else if (i == 2){
						xCoord = half*third*Screen.width + twoThirds*Screen.width;
					}
							
					if (j == 0){
						yCoord = half*third*Screen.height;		
					}
					else if (j == 1){
						yCoord = half*third*Screen.height + third*Screen.height;
					}
					else if (j == 2){
						yCoord = half*third*Screen.height + twoThirds*Screen.height;
					}
					GUI.Box(new Rect(xCoord, yCoord, 5, 5), i.ToString() + j.ToString());
				}
			}
		}
		
	}
	
}
