using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadTexture : MonoBehaviour {
    public RawImage RITarget;
    public RenderTexture RITexture; 
	
	void Start () {
        RITarget.texture = RITexture;
	}
    	
}
