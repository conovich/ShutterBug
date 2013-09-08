using UnityEngine;
using System.Collections;

public class TheState: MonoBehaviour {
	
	public static bool isPreviewing;
	
	public enum GameMode{
		start,
		exposure,
		ruleOfThirds
	}
	
	public static GameMode _TheMode;
	
	void Start () {
		isPreviewing = false;
		_TheMode = GameMode.exposure;
		
	}
	
	void Update () {
		if (isPreviewing == true) GuiLightSwitchOn();
		else GuiLightSwitchOff();
	}
	
	void GuiLightSwitchOn () {
		GameObject[] guiLights = GameObject.FindGameObjectsWithTag("guiLight");
		for (int i = 0; i < guiLights.Length; i++) {
			guiLights[i].light.intensity = 0.5f;
		}
	}
		
	void GuiLightSwitchOff () {
		GameObject[] guiLights = GameObject.FindGameObjectsWithTag("guiLight");
		for (int i = 0; i < guiLights.Length; i++) {
			guiLights[i].light.intensity = 0.0f;
		}
	}
}
