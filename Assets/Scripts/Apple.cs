using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody2D appleRB;
    
    // Start is called before the first frame update
    void Start()
    {
        appleRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onAttacked(){
        appleRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }
}
