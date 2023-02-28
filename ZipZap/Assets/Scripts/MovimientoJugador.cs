using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabsuelo;
    public Camera cam;
    private Vector3 offset;
    private float miX, miZ;
    private Rigidbody rb;
    private Vector3 direccionActual;
    public int velocidad; 
    void Start()
    {
        offset = cam.transform.position;
        miX = 0; miZ = 0;
        SueloInicial();
        rb = GetComponent<Rigidbody>();
        direccionActual = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = this.transform.position + offset;

        if(Input.GetKeyUp(KeyCode.Space)){
            if(direccionActual == Vector3.forward){
                direccionActual = Vector3.right;
            }else{
                direccionActual = Vector3.forward;   
            }
        }

        float tiempo = velocidad * Time.deltaTime;
        rb.transform.Translate(direccionActual * tiempo);
    }

    void SueloInicial(){
        for( int i = 0; i < 3; i++){
            miZ += 6.0f;
            GameObject elcubo = Instantiate(prefabsuelo, new Vector3(miX,0,miZ), Quaternion.identity) as GameObject;
        }
    }
}
