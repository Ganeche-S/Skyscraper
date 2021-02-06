using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
    public static float dropTime = 0.9f;
    public static float quickDropTime = 0.05f;
    float timer = 0f;
    bool movable = true;
    public static int width = 5, height = 4;
    public Vector3 rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool CheckValid() {
        foreach(Transform subBlock in transform) {
            if(subBlock.transform.position.x > width || subBlock.transform.position.x < -4 || subBlock.transform.position.y <-4) {
                return false;
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {       
        if(movable) {
            timer += 1 * Time.deltaTime;
            if(Input.GetKeyDown("s") && timer > quickDropTime) {
                gameObject.transform.position -= new Vector3(0,1,0);
                timer = 0;
                if(!CheckValid()) {
                    movable = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                }
            }
            else if(timer > dropTime) {
                    gameObject.transform.position -= new Vector3(0,1,0);
                    timer = 0;
                if(!CheckValid()) {
                    movable = false;
                    gameObject.transform.position += new Vector3(0,1,0);
                }
            }
            if(Input.GetKeyDown("q")) {
                gameObject.transform.position -= new Vector3(1,0,0);
                if(!CheckValid()) {
                    gameObject.transform.position += new Vector3(1,0,0);
                }
            }
            else if(Input.GetKeyDown("d")) {
                gameObject.transform.position += new Vector3(1,0,0);
                if(!CheckValid()) {
                    gameObject.transform.position -= new Vector3(1,0,0);
                }
            }
            else if(Input.GetKeyDown("a")){
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
                if(!CheckValid()) {
                    gameObject.transform.position -= new Vector3(1,0,0);
                }
            }
            else if(Input.GetKeyDown("e")){
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
                if(!CheckValid()){
                    gameObject.transform.position -= new Vector3(1,0,0);
                }
            }

    }

}
}
