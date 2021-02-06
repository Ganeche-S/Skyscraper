using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
	private float previousTime;
	public Vector3 rotationPoint;
	public float fallTime = 0.8f;
	public static int height = 4;
	public static int width = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")) 
		{
        	transform.position += new Vector3(-1,0,0);
        	if(!ValidMove()) {
        		transform.position -= new Vector3(-1, 0,0);
        	}

        }
        else if(Input.GetKeyDown("d")) 
		{
			transform.position += new Vector3(1,0,0);
			if(!ValidMove()) {
        		transform.position -= new Vector3(1, 0,0);
        	}
        }
		else if(Input.GetKeyDown("a"))
		{
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
			if(!ValidMove())
				transform.position -= new Vector3(1,0,0);
		}
		else if(Input.GetKeyDown("e"))
		{
			transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), -90);
			if(!ValidMove())
				transform.position -= new Vector3(1,0,0);
		}

        if(Time.time - previousTime >(Input.GetKey("s") ? fallTime /10 : fallTime)) {
        	transform.position += new Vector3(0,-1,0);
        	if(!ValidMove()) {
        		transform.position -= new Vector3(-1, 0,0);
        	}
        	previousTime = Time.time;
        }

    }

    bool ValidMove() {
    	foreach(Transform children in transform) {
    		int roundedX = Mathf.RoundToInt(children.transform.position.x);
    		int roundedY = Mathf.RoundToInt(children.transform.position.y);

    		Debug.Log(roundedX + ":" + roundedY); 

    		if(roundedX < -3 || roundedX >= width || roundedY < -4 || roundedY >= height) {
    			return false;
    			
    		}
    	}
    	return true;
    }
}
