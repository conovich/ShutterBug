using UnityEngine;
using System.Collections;

public class CaptureButton : MonoBehaviour {
	public bool _Capture;
	public bool _ScorePicture;
	
	void Start () {
		_Capture = false;
		_ScorePicture = false;
	}
	
	void Update () {
		CheckInput();
		
		if (TheState._TheMode == TheState.GameMode.ruleOfThirds && _ScorePicture){
			if(!CheckForRuleOfThirds()){
				_ScorePicture = false;
			}
		}
	}
	
	void CheckInput(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject == gameObject) {
					gameObject.renderer.material.color = Color.black;
					_Capture = true;
					_ScorePicture = true;
					gameObject.audio.Play();
				}
			}
		}	
		
		else{
			gameObject.renderer.material.color = Color.gray;
		}
	}
	
	
	//this should be refactored in the future...
	bool CheckForRuleOfThirds(){
		GameObject[,] intersectionGrid = new GameObject[3,3];
		
		float xCoord = 0.0f;
		float yCoord = 0.0f;
		float half = 0.5f;
		float third = 1.0f/3.0f;
		float twoThirds = 2.0f/3.0f;
		
		Vector3 cellCenterVector;
		
		RaycastHit rayCastData = new RaycastHit();
		
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
				
				//raycast from center of cell[i,j]
				//fill intersectionGrid with GameObjects
				cellCenterVector = new Vector3(xCoord, yCoord, 0.0f);
				Ray ray = Camera.main.ScreenPointToRay (cellCenterVector);
				if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
					intersectionGrid[i,j] = rayCastData.collider.gameObject;
				}
			}
		}
		//top row
		if (intersectionGrid[0,0] == intersectionGrid[0,1] && intersectionGrid[0,0] == intersectionGrid[0,2]){
			return true;	
		}
		//middle row
		if (intersectionGrid[1,0] == intersectionGrid[1,1] && intersectionGrid[1,0] == intersectionGrid[1,2]){
			return true;	
		}
		//bottom row
		if (intersectionGrid[2,0] == intersectionGrid[2,1] && intersectionGrid[2,0] == intersectionGrid[2,2]){
			return true;	
		}
		//left-most col
		if (intersectionGrid[0,0] == intersectionGrid[1,0] && intersectionGrid[0,0] == intersectionGrid[2,0]){
			return true;	
		}
		//middle col
		if (intersectionGrid[0,1] == intersectionGrid[1,1] && intersectionGrid[0,1] == intersectionGrid[2,1]){
			return true;	
		}
		//right-most col
		if (intersectionGrid[0,2] == intersectionGrid[1,2] && intersectionGrid[0,2] == intersectionGrid[2,2]){
			return true;	
		}
		
		Debug.Log("Not Rule of Thirds");
		return false;
	}
	
}
