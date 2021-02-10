using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPhysics : MonoBehaviour
{
    private Rigidbody2D rb;   
    public Vector2 movement;
    public float fallSpeed = 6.0f;
    public bool collide;
    
    // Start is called before the first frame update
    void Start()
    { 
        this.rb = gameObject.GetComponent<Rigidbody2D>();    
        this.rb.velocity = new Vector2(0, -2.0f);
        
        collide = false;
    }

    // Update is called once per frame
    void Update()
    {           
        if(collide == false)
            CheckUserInput(); 
        
        if(gameObject.transform.position.y<3)
        {
            Destroy(gameObject);
            Destroy(this.rb);
            Destroy(this);
        }
    } 

    //
    void CheckUserInput()
    { 
        if(Input.GetKey("s"))
        {
            this.rb.velocity = new Vector2(0, -6.0f);
        }
        else 
        {
            this.rb.velocity = new Vector2(0, -2.0f);
            if(Input.GetKeyDown("q"))
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
    }

    //
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Block" || c.gameObject.tag == "Ground")
        { 
            collide = true;
        }
    }
}
