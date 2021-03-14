using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Playerscript : MonoBehaviour 
{

    private Rigidbody2D rd2d; 
    public float speed;
    public Text score;  
    private int scoreValue; 

    public Text YouWin;

    private int lives; 
    public Text Lives; 
     
    

    // Start is called before the first frame update
    void Start()
    {
        rd2d=GetComponent<Rigidbody2D>(); 
       scoreValue= 0; 
       YouWin.text=score.text; 
        SetScoreText(); 
        lives=3; 
        Lives.text= "Lives:" + lives.ToString(); 
        
        
        
         
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement= Input.GetAxis("Horizontal"); 
        float vertMovement= Input.GetAxis("Vertical"); 
        rd2d.AddForce(new Vector2(hozMovement* speed, vertMovement*speed)); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag =="Coin")
        {
            scoreValue +=1; 
            SetScoreText(); 
            Destroy(collision.collider.gameObject);
            
        }
         
      
    


        }
    

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag=="Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0,3), ForceMode2D.Impulse); 
            }
        }
        
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            } 
        }
        if (collision.collider.tag=="Enemy")
       {
           lives=- 1; 
           Lives.text=lives.ToString(); 
       }
       
    }
    void SetScoreText() 
    {
        
        score.text= "Score:" + scoreValue.ToString();
        
        
        
        if (scoreValue >= 4 )

             {
                YouWin.text="You Win! Game by Aaron Simons" ;
             }
      
    }
   
      
        
}

   