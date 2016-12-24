using UnityEngine;
using System.Collections;

public class Move_Sphere : MonoBehaviour {
    private int y_max = 130;
    private int y = 0;
   
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        y += 10;
        transform.position = new Vector3(-10000, y, -1000);
        if (y > y_max) { y = 0; }
        
    }
}
