using System;
using System.IO;

using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject[] Blocks; 
    public GameObject CurrentBlock;     
    
    public Vector3 position;
    public int life;
    public int score;
 
    // Start is called before the first frame update
    void Start()
    {    
        position = new Vector3(18, 19, 0);
        life = 7;

        SpawnBlock(); // Initiate the first block to start the "loop" 
    }

    public void Update()
    {
        Blocks = GameObject.FindGameObjectsWithTag("Block");

        // Reset the level 
        if(Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        if(!EndGame())
        {  
            if(CurrentBlock == null || CurrentBlock.GetComponent<Block>().IsDead() || CurrentBlock.GetComponent<Block>().HasCollide())
            {
                if(CurrentBlock.GetComponent<Block>().IsDead())
                {
                    CurrentBlock.GetComponent<Block>().Harakiri(); 
                    CurrentBlock = null;
                    life--;
                } 
                SpawnBlock();
            }
        }
        else
        {
            score = CountPlayerScore(); 
        } 
    }  
    
    public int CountPlayerScore()
    {
        int s = 0;
        int length = GameObject.FindGameObjectsWithTag("Block").Length;
        for(int i=0; i<length/10; i++)
        {
            if(i == (length/10)-1)
                s += (i+1)*(length%10);
            else
                s += (i+1)*10;
        }

        return s;
    }

    public bool EndGame()
    {
        if(life <= 0)
            return true;

        bool collision = false; 
        
        Blocks = GameObject.FindGameObjectsWithTag("Block");
        for(int i=0; i<Blocks.Length; i++)
        { 
            if(Blocks[i] != null && Blocks[i].GetComponent<Block>() != null)
            {
                if(Blocks[i].GetComponent<Block>().IsDead())
                {
                    Blocks[i].GetComponent<Block>().Harakiri(); 
                    Blocks[i] = null;
                    life--;
                } 
                else 
                {
                    collision = Blocks[i].GetComponent<Block>().HasCollide();
                    if(collision && Blocks[i].transform.position.y>=18) 
                    {
                        return true;
                    }   
                } 
            }
        } 
        return false;
    }

    public void SpawnBlock()
    {
        CurrentBlock = Instantiate(Resources.Load<GameObject>(GetRandomBlock()), position, Quaternion.identity) as GameObject; 
    }

    public string GetRandomBlock()
    {
        int random = UnityEngine.Random.Range(1,8);

        string randomBlock = "Prefabs/";

        switch(random)
        {
            case 1:
                randomBlock += "Block_I";
                break;
            case 2:
                randomBlock += "Block_O";
                break;
            case 3:
                randomBlock += "Block_LL";
                break;
            case 4:
                randomBlock += "Block_LR";
                break;
            case 5:
                randomBlock += "Block_S";
                break;
            case 6:
                randomBlock += "Block_Z";
                break;
            case 7:
                randomBlock += "Block_T";
                break;
        } 

        return randomBlock;
    }
 
}
