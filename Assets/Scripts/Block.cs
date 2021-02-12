using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb;   
    private bool collide;   
    private bool dead;

    public int minWidth = 10;
    public int maxWidth = 26;
    
    // Start is called before the first frame update
    void Start()
    { 
        this.rb = gameObject.GetComponent<Rigidbody2D>();    
        this.rb.velocity = new Vector2(0, -2.0f);
        
        this.collide = false;  
        this.dead = false;
    }

    // Update is called once per frame
    void Update()
    {            
        if(!collide)
        {
            CheckUserInput(); 
        }

        if(gameObject.transform.position.y<3)
        {
            this.dead = true; 
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
                if(!ValidMove()) 
                {
                    gameObject.transform.position -= new Vector3(-1, 0, 0);
                }
            }
            else if(Input.GetKeyDown("d"))
            {
                gameObject.transform.position += new Vector3(1, 0, 0);
                if(!ValidMove()) 
                {
                    gameObject.transform.position -= new Vector3(1, 0, 0);
                }
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

    public bool IsDead()
    {
        return this.dead;
    }

    public Rigidbody2D getRigidbody()
    {
        return this.rb;
    }
 
    public void Harakiri()
    { 
        Destroy(gameObject);   
    }

    //
    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Block" || c.gameObject.tag == "Ground")
        { 
            collide = true;
        }
    }

    bool ValidMove() 
    {
    	foreach(Transform children in transform) 
        {
    		int roundedX = Mathf.RoundToInt(children.transform.position.x);
    		int roundedY = Mathf.RoundToInt(children.transform.position.y); 

    		if(roundedX <= minWidth || roundedX >= maxWidth) 
            {
    			return false; 
    		}
    	}
    	return true;
    }
}
