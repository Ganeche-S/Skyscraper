using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; 
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject[] Blocks; 
    public GameObject CurrentBlock; 
    
    public Canvas GameOver;
    public TextMeshProUGUI Life;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI FinalScore; 

    public Vector3 position;
    public int life;
    public int score;
    public bool end;
 
    // Start is called before the first frame update
    void Start()
    {    
        position = new Vector3(18, 19, 0);
        life = 5;
        end = false;

        SpawnBlock(); // Initiate the first block to start the "loop" 
    }

    public void Update()
    {
        score = CountPlayerScore();
        Score.text = "Score : " + score.ToString();
        Life.text = "Life : " + life.ToString();

        Blocks = GameObject.FindGameObjectsWithTag("Block");

        // Reset the level 
        if(Input.GetKeyDown("r"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
        EndGame();
        if(!end)
        {  
            if(CurrentBlock == null || CurrentBlock.GetComponent<Block>().IsDead() || CurrentBlock.GetComponent<Block>().HasCollide())
            {
                if(CurrentBlock.GetComponent<Block>().IsDead())
                {
                    CurrentBlock.GetComponent<Block>().Harakiri(); 
                    CurrentBlock = null; 
                } 
                SpawnBlock();
            }
        }
        else
        {
            FinalScore.text = "Score : " + score.ToString();
            GameOver.gameObject.SetActive(true);
        } 
    }  
    
    public int CountPlayerScore()
    { 
        if(!end)
        {
            int s = 0;
            int length = 0;
            
            for(int i=0; i<Blocks.Length; i++)
            { 
                if(Blocks[i] != null && Blocks[i].GetComponent<Block>() != null && Blocks[i].GetComponent<Block>().HasCollide())
                    length++;
            }

            for(int i=0; i<length; i++)
            { 
                s += 10*((i/10)+1);
            }

            return s;
        }
        else
        {
            return score;
        } 
    }



    public void EndGame()
    {
        if(life <= 0)
            end = true;

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
                    if(collision && Blocks[i].transform.position.y>=17) 
                    {
                        end = true;
                    }   
                } 
            }
        }
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
