using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public GameObject fence;
    public BoxCollider2D fenceBC;
    // Start is called before the first frame update
    void Start()
    {
        fenceBC = fence.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "enemy"){
            Vector2 opposite = -other.GetComponent<Enemy>().enemyRB.velocity;
            other.GetComponent<Enemy>().enemyRB.AddForce(opposite*20, ForceMode2D.Impulse);
        }
    }*/
}
