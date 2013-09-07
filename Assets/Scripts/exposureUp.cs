using UnityEngine;
using System.Collections;

public class exposureDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject.tag == "topButton") {
					rayCastData.collider.gameObject.renderer.material.color = Color.black;
					GameObject[] lights = GameObject.FindGameObjectsWithTag("ambLight");
					for (int i = 0; i < lights.Length; i++ ) {
						lights[i].light.intensity += 1.0f;
					}
				}
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				if (rayCastData.collider.gameObject.tag == "topButton")
					rayCastData.collider.gameObject.renderer.material.color = Color.white;
			}
		}
		
	}
}
