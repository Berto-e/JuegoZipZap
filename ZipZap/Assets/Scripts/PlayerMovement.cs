using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject prefabsuelo;
    public Camera cam;
    private Vector3 offset;
    private float miX, miZ;
    private Rigidbody rb;
    private Vector3 direccionActual;
    private Vector3 initpos;
    public int velocidad;
    private int coins; 
    public TMP_Text CoinText;
    private AudioSource Coinsound;
    void Start()
    {
        offset = cam.transform.position;
        initpos = this.transform.position;
        coins = 0;
        miX = 0; miZ = 0;
        //SueloInicial();
        rb = GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;
        Coinsound = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = this.transform.position + offset;

        //Movement
        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward){
                direccionActual = Vector3.left;
            }else{
                direccionActual = Vector3.forward;   
            }
        }
        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate(direccionActual * tiempo);
        //End_Movement

        //Die
        if(this.transform.position.y < -1)
            restartGame();
        //End_Die

        

    }

    void restartGame(){
        this.transform.position = initpos;
        rb.Sleep();
        direccionActual = Vector3.zero;
    }
     void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("coin")){
            coins++;
            Coinsound.Play();
            //CoinText
            CoinText.text = ":" + coins.ToString();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == ("suelo")){
            StartCoroutine(CrearSuelo(other));
        }
    }

    IEnumerator CrearSuelo(Collider other){
        yield return new WaitForSeconds(1f);
        other.GetComponent<Rigidbody>().isKinematic = false;
        other.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(2f);
        Destroy(other.gameObject);

    }
    /*void SueloInicial(){
        for( int i = 0; i < 3; i++){
            miZ += 6.0f;
            GameObject elcubo = Instantiate(prefabsuelo, new Vector3(miX,0,miZ), Quaternion.identity) as GameObject;
        }
    }*/
}