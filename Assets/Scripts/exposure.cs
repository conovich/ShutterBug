using UnityEngine;
using System.Collections;

public class exposure : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				GameObject button = rayCastData.collider.gameObject;
				if (button.tag == "topButton" && button == gameObject) {
					GameObject[] lights = GameObject.FindGameObjectsWithTag("ambLight");
					for (int i = 0; i < lights.Length; i++ ) {
						lights[i].light.intensity += (float) 0.1/lights.Length;
					}
					TheState.exposure++;
				}
				else if (button.tag == "bottomButton" && button == gameObject && TheState.exposure >= 0) {
					GameObject[] lights = GameObject.FindGameObjectsWithTag("ambLight");
					for (int i = 0; i < lights.Length; i++ ) {
						lights[i].light.intensity -= (float) 0.1/lights.Length;
					}
					TheState.exposure--;
				}
			}
		}
	}
}
