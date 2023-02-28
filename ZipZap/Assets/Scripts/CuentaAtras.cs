using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CuentaAtras : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn;
    public Image img;
    public Sprite[] numeros;
    private int mostrar;
    private bool contar;
    void Start()
    {
        btn.onClick.AddListener(Pulsado);
        contar = false;
        mostrar = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if(contar){
            switch (mostrar)
            {
                case 0: Debug.Log("Saltar a otra escena"); break;
                case 1: img.sprite = numeros[0]; break;
                case 2: img.sprite = numeros[1]; break;
                case 3: img.sprite = numeros[2]; break;
               
            }
            StartCoroutine(Esperar());
            contar = false;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1);
        contar = true;
        mostrar --;
    }

    void Pulsado(){
        img.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        contar = true;
    }
}
