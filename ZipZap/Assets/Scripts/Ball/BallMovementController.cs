using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BallMovementController : MonoBehaviour
{
    [SerializeField] private BallDataTransmiter ballDataTransmiter;

    [SerializeField] private float ballMoveSpeed;
    public TMP_Text CoinText;
    public TMP_Text LivesText;
    public AudioSource CoinSound;
    private Rigidbody rb;
    private int Coins = 0;
    private  void Start() 
    {
        LivesText.text = ":" + StaticClass.Lives.ToString();
    }
    
    private void Update()
    {
        SetBallMovement();
        rb = GetComponent<Rigidbody>();
        CoinSound = GetComponent<AudioSource>();
        
        //Levels and Die 
        if(Coins == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if(this.transform.position.y < -1f && StaticClass.Lives > 1)
        {
            StaticClass.Lives--;
            LivesText.text = ":" + StaticClass.Lives.ToString();
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Load Actual Scene
        }
        else if(this.transform.position.y < -1f && StaticClass.Lives == 1)
        {
            SceneManager.LoadScene("EndScene",LoadSceneMode.Single);
        }


    }
   
    private void SetBallMovement()
    {
        transform.position+= ballDataTransmiter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("coin"))
        {
            CoinSound.Play();
            Destroy(other.gameObject);
            Coins++;
            CoinText.text = ":" + Coins.ToString();
        }    
    }

   
}
