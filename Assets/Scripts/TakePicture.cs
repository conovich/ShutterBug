using UnityEngine;
using System.Collections;

public class TakePicture : MonoBehaviour {
	GameObject ImagePlaneObj;
	GameObject CaptureButtonObj;
	CaptureButton CaptureButton;
		
	public bool grab = true;
    public Renderer display;
	
	// Use this for initialization
	void Start () {
		ImagePlaneObj = GameObject.FindGameObjectWithTag("imagePlane");
		CaptureButtonObj = GameObject.FindGameObjectWithTag("captureButton");
		CaptureButton = CaptureButtonObj.GetComponent<CaptureButton>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPostRender() {
        if (CaptureButton._Capture) {
            Texture2D tex = new Texture2D(600, 600, TextureFormat.ARGB32, false);
            tex.ReadPixels(new Rect(0, 0, 600, 600), 0, 0);
            tex.Apply();
			display.material.mainTexture = tex;
			//ImagePlane.renderer.material = display.material;
            //ImagePlane.renderer.material.mainTexture = tex;
            CaptureButton._Capture = false;
        }
    }
}
