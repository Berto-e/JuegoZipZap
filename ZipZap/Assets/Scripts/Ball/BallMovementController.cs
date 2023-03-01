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
    public AudioSource CoinSound;
    private Rigidbody rb;
    private int Coins = 0;

    private void Update()
    {
        SetBallMovement();
        rb = GetComponent<Rigidbody>();
        CoinSound = GetComponent<AudioSource>();
        if(Coins == 10)
        {
            EndGame();
        }
        if(this.transform.position.y < -1f)
        {
            SceneManager.LoadScene("ZigZagEasy",LoadSceneMode.Single);
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

    private void EndGame()
    {
        SceneManager.LoadScene("EndScene",LoadSceneMode.Single);
    }
}
