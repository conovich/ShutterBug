using UnityEngine;
using System.Collections;

public class TakePicture : MonoBehaviour {
	GameObject ImagePlaneObj;
	GameObject CaptureButtonObj;
	CaptureButton CaptureButton;
		
	public bool grab = true;
    public Renderer[] _Display;
	private int _numShots;
	
	// Use this for initialization
	void Start () {
		ImagePlaneObj = GameObject.FindGameObjectWithTag("imagePlane");
		CaptureButtonObj = GameObject.FindGameObjectWithTag("captureButton");
		CaptureButton = CaptureButtonObj.GetComponent<CaptureButton>();
		_numShots = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPostRender() {
		if(_numShots < _Display.Length){
	        if (CaptureButton._Capture) {
	            Texture2D tex = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
	            tex.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
	            tex.Apply();
				_Display[_numShots].material.mainTexture = tex;
				_numShots++;
				//ImagePlane.renderer.material = display.material;
	            //ImagePlane.renderer.material.mainTexture = tex;
	            CaptureButton._Capture = false;
	        }
		}
    }
}
