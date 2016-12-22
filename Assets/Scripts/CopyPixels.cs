using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CopyPixels : MonoBehaviour {
    public Camera RenderCamera;

    public RawImage destination;
    public RawImage RIWebCam;
    public RawImage RICompound;

    //public Material sourceMat;
    public Material destinationMat;

    private Texture2D sourceT2D;
    private Texture2D destinationT2D;
    private Texture2D compoundT2D;
    private WebCamTexture WCTexture;

    public float rojo;
    public float verde;
    public float azul;

    // Use this for initialization
    void Start () {

        rojo = 0.2f;
        verde = 0.2f;
        azul = 0.2f;

        WCTexture = new WebCamTexture();
        RIWebCam.texture = WCTexture;
        RIWebCam.material.mainTexture = WCTexture;
        WCTexture.Play();

        sourceT2D = new Texture2D(640, 480);
        destinationT2D = new Texture2D(640, 480);
        compoundT2D = new Texture2D(640, 480);

        sourceT2D = CopyTexture(640, 480);
        sourceT2D.Apply();
        destination.material = destinationMat;

    }
	
	//Update is called once per frame
	void Update () {
       
       Color[] source_pixels = sourceT2D.GetPixels();
       Color[] webcam_pixels = WCTexture.GetPixels();
       Color[] compound_pixels = new Color[307200];

        destinationT2D.SetPixels(source_pixels);
        destinationT2D.Apply();
        destinationMat.mainTexture = destinationT2D;

        for (int i = 0; i < webcam_pixels.Length - 1; i++)
        {
            Color pixel = webcam_pixels[i];
            if (pixel.r < rojo && pixel.g > verde && pixel.b < azul)
            {
                compound_pixels[i] = source_pixels[i];              
            } else {
                compound_pixels[i] = webcam_pixels[i];
            }
        }
        
        compoundT2D.SetPixels(compound_pixels);
        compoundT2D.Apply();
        RICompound.texture = compoundT2D;
        
    }

    private Texture2D CopyTexture(int t_width, int t_height)
    {
        RenderTexture renderTexture = new RenderTexture(t_width, t_height, 24);
        Texture2D newTexture = new Texture2D(t_width, t_height, TextureFormat.ARGB32, false);

        RenderCamera.aspect = 1.0f;
        RenderCamera.targetTexture = renderTexture;
        RenderCamera.Render();

        RenderTexture.active = renderTexture;
        newTexture.ReadPixels(new Rect(0.0f, 0.0f, t_width, t_height), 0, 0);
        RenderTexture.active = null;
        RenderCamera.targetTexture = null;

        newTexture.Apply();
        return newTexture;
    }
}
