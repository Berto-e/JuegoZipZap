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
    //private float miZ,miX;
    private Vector3 lastfloor;
    private Rigidbody rb;
    private Vector3 direccionActual;
    public int velocidad;
    private int coins; 
    public TMP_Text CoinText;
    private AudioSource Coinsound;
    void Start()
    {
        offset = cam.transform.position;
        coins = 0;
         //miZ = 0;
         //miX = 0;
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
        this.transform.position = lastfloor;
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


    private void OnCollisionStay(Collision other) {
        lastfloor = other.transform.position;
    }

    /*void OnCollisionExit(Collision other) {
        if(other.transform.tag == "suelo"){
            StartCoroutine(CrearSuelo(other));
        }
    }
    IEnumerator CrearSuelo(Collision col){
        yield return new WaitForSeconds(0.5f);
        col.rigidbody.isKinematic = false;
        col.rigidbody.useGravity = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(col.gameObject);
        float ran = Random.Range(0f,1f);
        if(ran < 0.5f)
            miX+=6.0f;
        else
            miZ+=6.0f;

        
        }*/

        /*void SueloInicial(){
        for( int i = 0; i < 1; i++){
            miZ += 6.0f;
            GameObject elcubo = Instantiate(prefabsuelo, new Vector3(miX,0,miZ), Quaternion.identity) as GameObject;
            intifloor = elcubo.transform.position;
        }
    }*/
    

}