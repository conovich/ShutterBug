using UnityEngine;
using System.Collections;

public class TheState: MonoBehaviour {
	
	public static bool isPreviewing;
	
	public static TheState _MyState;
	
	private TheState() {}
	
	public static TheState Instance{
		get{
			if (_MyState == null){
				_MyState = new TheState();	
			}
			return _MyState;
		}
	}
	
	void Start () {
		isPreviewing = false;
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
