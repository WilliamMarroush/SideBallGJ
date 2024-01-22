using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownApple : MonoBehaviour
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
}
