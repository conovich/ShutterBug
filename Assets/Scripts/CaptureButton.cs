using UnityEngine;
using System.Collections;

public class CaptureButton : MonoBehaviour {
	public bool _Capture;
	
	void Start () {
		_Capture = false;
	}
	
	void Update () {
		CheckInput();
	}
	
	void CheckInput(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject == gameObject) {
					gameObject.renderer.material.color = Color.black;
					_Capture = true;
				}
			}
		}	
		
		else{
			gameObject.renderer.material.color = Color.gray;
		}
	}
}
