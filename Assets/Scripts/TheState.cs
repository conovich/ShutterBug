using UnityEngine;
using System.Collections;

public class TheState: MonoBehaviour {
	
	public static bool isPreviewing;
	public static int exposure;
	
	public enum GameMode{
		start,
		exposure,
		ruleOfThirds
	}
	
	public static GameMode _TheMode;
	
	void Start () {
		isPreviewing = false;
		_TheMode = GameMode.exposure;
		exposure = 5;
		
	}
	
	void Update () {
	}
}
