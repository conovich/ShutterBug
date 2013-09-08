using UnityEngine;
using System.Collections;

public class exposureUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject.tag == "bottomButton") {
					rayCastData.collider.gameObject.renderer.material.color = Color.blue;
					GameObject[] lights = GameObject.FindGameObjectsWithTag("ambLight");
					for (int i = 0; i < lights.Length; i++ ) {
						lights[i].light.intensity -= (float) 0.5/lights.Length;
					}
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject.tag == "bottomButton")
					rayCastData.collider.gameObject.renderer.material.color = Color.white;
			}
		}
		
	}
}
