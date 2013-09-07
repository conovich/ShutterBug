using UnityEngine;
using System.Collections;

public class ImagePlane : MonoBehaviour {
	private bool IsBig;
	private Vector3 ThumbnailSize;
	private Vector3 ThumbnailPos;
	
	void Start(){
		IsBig = false;
		ThumbnailSize = new Vector3(0.078493f, 0.052329f, 0.052329f);
		ThumbnailPos = gameObject.transform.localPosition;
	}
	
	//LOADS A SAVED IMAGE ON START
	/*IEnumerator Start () {
			// Create a texture in DXT1 format
		renderer.material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
		
		string FilePath = "file://" + Application.dataPath + "/Resources/images/Cocoa.jpg";
		
		while(true) {
			// Start a download of the given URL
			var www = new WWW(FilePath);
			// wait until the download is done
			yield return www;
			// assign the downloaded image to the main texture of the object
			Texture2D tex = (Texture2D)renderer.material.mainTexture;
			www.LoadImageIntoTexture(tex);
		}
	}*/
	
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit rayCastData = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out rayCastData, 100.0f)) {
				GameObject picture = rayCastData.collider.gameObject;
				if (picture.tag == "imagePlane" && picture == gameObject) {
					if (IsBig == false && TheState.isPreviewing == false) {
						picture.transform.localScale *= 10;
						picture.transform.localPosition = new Vector3(0.0f, 5.0f, -7.0f);
						IsBig = true;
						TheState.isPreviewing = true;
					}
					else if (IsBig == true && TheState.isPreviewing == true) {
						picture.transform.localScale = ThumbnailSize;
						picture.transform.localPosition = ThumbnailPos;
						IsBig = false;
						TheState.isPreviewing = false;
					}
				}
			}
		}
	}
	
	void LoadImage() {
		
	}
	
}
