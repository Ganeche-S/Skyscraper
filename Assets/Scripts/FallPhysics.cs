using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPhysics : MonoBehaviour
{
    private Rigidbody2D rb; 
    private bool asleep;

    public float fallTime = 0.0f;
    public float fallSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody2D>();   
        asleep = true;
    }

    // Update is called once per frame
    void Update()
    {       
        if(asleep)
            CheckUserInput(); 
    }

    //
    void CheckUserInput()
    {
        if (Input.GetKeyDown("s") || Time.time - fallTime >= fallSpeed)
        {
            gameObject.transform.position += new Vector3(0, -1, 0);
            fallTime = Time.time;
        }
        else if(Input.GetKeyDown("q"))
        {
            gameObject.transform.position += new Vector3(-1, 0, 0);
        }
        else if(Input.GetKeyDown("d"))
        {
            gameObject.transform.position += new Vector3(1, 0, 0);
        }
        else if(Input.GetKeyDown("a"))
        {
            gameObject.transform.Rotate(0, 0, 90);
        }
        else if(Input.GetKeyDown("e"))
        {
            gameObject.transform.Rotate(0, 0, -90);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Block" || c.gameObject.tag == "Ground")
        {
            rb.gravityScale = 1.0f;
            asleep = false;
            rb.WakeUp();
        }
    }
}
