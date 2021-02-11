using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Game : MonoBehaviour
{
    public GameObject[] Blocks; 
    public GameObject currentBlock;  
    // public int score;
 
    // Start is called before the first frame update
    void Start()
    {   
        // score = 0; 

        SpawnBlock(); // Initiate the first block to start the "loop" 
    }

    public void Update()
    {
        if(!EndGame())
        {
            Blocks = GameObject.FindGameObjectsWithTag("Block");
            if(currentBlock.GetComponent<Block>().HasCollide())
            {
                SpawnBlock();
            }
        }
        // score = CountPlayerScore(); 
    }  
    
    // public int CountPlayerScore()
    // {
    //     int s = 0;
    //     int length = GameObject.FindGameObjectsWithTag("Block").Length;
    //     for(int i=0; i<length/10; i++)
    //     {
    //         if(i == (length/10)-1)
    //             s += (i+1)*(length%10);
    //         else
    //             s += (i+1)*10;
    //     }

    //     return s;
    // }

    public bool EndGame()
    {
        bool collision = false;
        foreach(GameObject go in Blocks)
        {
            collision = go.GetComponent<Block>().HasCollide();
            if(collision && go.transform.position.y>=18) 
            {
                return true;
            }
        }
        return false;
    }

    public void SpawnBlock()
    {
        Vector3 position = new Vector3(18, 19, 0);
        currentBlock = (GameObject) Instantiate(Resources.Load<GameObject>(GetRandomBlock()), position, Quaternion.identity);
    
    }

    public string GetRandomBlock()
    {
        int random = Random.Range(1,8);

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
        Debug.Log(randomBlock);

        return randomBlock;
    }
     
}
