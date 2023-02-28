using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
      private Vector3 rotation = new Vector3(0,0,90);
      private float speed = 3;
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(rotation * speed * Time.deltaTime);
    }
    
}
