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
				GameObject arrow = rayCastData.collider.gameObject;
				if (arrow.tag == "rightArrow") {
					gameObject.transform.Rotate(0.0f, 9.0f, 0.0f);
				}
				if (arrow.tag == "leftArrow") {
					gameObject.transform.Rotate(0.0f, -9.0f, 0.0f);
				}
				if (arrow.tag == "walkForward") {
					Vector3 facing = Camera.main.transform.forward;
					gameObject.transform.position += new Vector3(2 * facing.x, 0.0f, 2 * facing.z);
				}
				if (arrow.tag == "walkBack") {
					Vector3 facing = Camera.main.transform.forward;
					gameObject.transform.position -= new Vector3(2 * facing.x, 0.0f, 2 * facing.z);
				}
			}
		}
	}
	
}


