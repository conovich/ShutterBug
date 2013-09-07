using UnityEngine;
using System.Collections;

public class ImagePlane : MonoBehaviour {

	IEnumerator Start () {
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
	}
	
	void Update () {
		
	}
	
	void LoadImage() {
		
	}
	
}
