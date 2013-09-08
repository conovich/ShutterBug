using UnityEngine;
using System.Collections;

public class ScoreGUI : MonoBehaviour {
	private int _myScore;
	private GameObject _captureButtonObj;
	private CaptureButton _captureButton;
	
	
	public static ScoreGUI _TheScore;
	
	private ScoreGUI() {}
	
	public static ScoreGUI Instance{
		get{
			if (_TheScore == null){
				_TheScore = new ScoreGUI();	
			}
			return _TheScore;
		}
	}
	
	
	// Use this for initialization
	void Start () {
		_myScore = 0;
		gameObject.guiText.text = _myScore.ToString();
		
		_captureButtonObj = GameObject.FindGameObjectWithTag("captureButton");
		_captureButton = _captureButtonObj.GetComponent<CaptureButton>();
	}
	
	// Update is called once per frame
	void Update () {
		if(_captureButton._ScorePicture){
			if(TheState._TheMode == TheState.GameMode.exposure){
				ScoreExposurePicture();
			}
			else if(TheState._TheMode == TheState.GameMode.ruleOfThirds){
				ScoreRuleOfThirdsPicture();
			}
		}
	}
	
	void ScoreExposurePicture(){
		//come up with scoring system!
		int points = 5 - Mathf.Abs(5 - TheState.exposure);
		if (points >= 0)_myScore += points;
		gameObject.guiText.text = _myScore.ToString();
		_captureButton._ScorePicture = false;
	}
	
	void ScoreRuleOfThirdsPicture(){
		//come up with scoring system!
		_myScore += 10;
		gameObject.guiText.text = _myScore.ToString();
		_captureButton._ScorePicture = false;
	}
}
