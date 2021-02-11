using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb;   
    private bool collide;   
    
    // Start is called before the first frame update
    void Start()
    { 
        this.rb = gameObject.GetComponent<Rigidbody2D>();    
        this.rb.velocity = new Vector2(0, -2.0f);
        
        this.collide = false;  
    }

    // Update is called once per frame
    void Update()
    {            
        if(!collide)
            CheckUserInput(); 

        if(gameObject != null && gameObject.transform.position.y<3)
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

    public bool HasCollide() 
    {
        return this.collide;
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
