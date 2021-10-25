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
    public Text Lose; 
    Animator anim;
    private bool Rightfacing=true; 

    public AudioSource musicalSource; 
    public AudioClip Win; 
    public AudioClip BackgroundMusic; 
    
    

    // Start is called before the first frame update
    void Start()
    {
        rd2d=GetComponent<Rigidbody2D>(); 
        
        anim = GetComponent<Animator>();
       scoreValue= 0; 
       YouWin.text=""; 
        SetScoreText(); 
        Lose.text=""; 
        lives = 3; 
        Lives.text="Lives:"+ lives.ToString(); 
        musicalSource.clip=BackgroundMusic; 
        musicalSource.Play(); 
        
        
        
         
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement= Input.GetAxis("Horizontal");
        anim.SetInteger("State", 1);
            
         
        
        float vertMovement= Input.GetAxis("Vertical");
          anim.SetInteger("State", 2);
          
        
        rd2d.AddForce(new Vector2(hozMovement* speed, vertMovement*speed)); 
        float moveHorizontal=moveHorizontal=Input.GetAxis("Horizontal");
        if (Rightfacing==false && moveHorizontal>0)
        {
            Rightfacing=!Rightfacing; 
            Vector2 Scaler=transform.localScale;
            Scaler.x=Scaler.x*-1;
            transform.localScale=Scaler; 
        }
        else if(Rightfacing== true&&moveHorizontal<0)
        {
            Rightfacing=!Rightfacing; 
            Vector2 Scaler=transform.localScale;
            Scaler.x=Scaler.x*-1;
            transform.localScale=Scaler; 
        }
       
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag=="Enemy")
        {
            lives -=1; 
            Lives.text="Lives" + lives.ToString(); 
            transform.position=new Vector3(0,0,0); 
            Destroy(collision.collider.gameObject); 
              
            
        }
        if(collision.collider.tag=="Enemy2")
        {
             lives -=1; 
            Lives.text="Lives" + lives.ToString(); 
            transform.position=new Vector3(78.8f,0.2f,0); 
            Destroy(collision.collider.gameObject);  
        }
        if (lives<=0)
        {
            Destroy(this);
            Destroy(gameObject); 
            Lose.text="You Lose! Press R to restart!"; 
        }
        
       
        
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
            anim.SetInteger("State", 0);
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0,3), ForceMode2D.Impulse);
                anim.SetInteger("State", 2);
                
                
                 


            }
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("State", 1);
                  
                 
            }
            if(Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("State", 1);
                
                
              
            }
            
            
        }

         
        

        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            } 
        }
       
       
    }
    void SetScoreText() 
    {
        
        score.text= "Score:" + scoreValue.ToString();
        
        
        
        if (scoreValue == 4 )

             {
               transform.position=new Vector3(86.5f,2,0);
                 
              
                if(lives<3)
                {
                    lives=3;
                    Lives.text="Lives"+lives.ToString(); 
                }
             }
              
            
        if (scoreValue>=8)
        {
            YouWin.text="You Win! Game by Aaron Simons.";
            musicalSource.clip = Win; 
            musicalSource.Play();  
            Destroy(this); 
            Destroy(gameObject); 
        }
      
    }
   
      
        
}

   