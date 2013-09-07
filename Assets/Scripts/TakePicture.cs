using UnityEngine;
using System.Collections;

public class TakePicture : MonoBehaviour {
	GameObject ImagePlane;
		
	public bool grab = true;
    public Renderer display;
	
	// Use this for initialization
	void Start () {
		ImagePlane = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPostRender() {
        if (true) {
            Texture2D tex = new Texture2D(128, 128);
            tex.ReadPixels(new Rect(0, 0, 128, 128), 0, 0);
            tex.Apply();
            ImagePlane.renderer.material.mainTexture = tex;
            grab = false;
        }
    }
}
