using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 1000.0f)) {
				if (rayCastData.collider.gameObject.tag == "rightArrow") {
					//gameObject.transform.Rotate(0.0f, 9.0f, 0.0f);
				}
				if (rayCastData.collider.gameObject.tag == "leftArrow") {
					//gameObject.transform.Rotate(0.0f, -9.0f, 0.0f);
				}
			}
		}
	}
	
}


