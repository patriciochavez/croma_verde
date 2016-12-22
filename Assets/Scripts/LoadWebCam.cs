using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadWebCam : MonoBehaviour {
    public RawImage RIWebCam;

    private WebCamTexture WCTexture;

	// Use this for initialization
	void Start () {
        WCTexture = new WebCamTexture();
        RIWebCam.texture = WCTexture;
        RIWebCam.material.mainTexture = WCTexture;
        WCTexture.Play();

    }	
}
