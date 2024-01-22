using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerrb;

    private GameObject[] stashList;
    private GameObject[] pitList;
    public GameObject applePrefab;
    private GameObject apple;

    private bool hasApple = false;
    public int team;
    //public int playerScore=0;
    // Start is called before the first frame update
    void Start()
    {
        playerrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        stashList = GameObject.FindGameObjectsWithTag("stash");
        pitList = GameObject.FindGameObjectsWithTag("pit");

        if ((other.CompareTag("pit")) && (!hasApple) && (other.GetComponent<Ballpit>().bpID == team))
        {
            Debug.Log("player picked up apple");
            hasApple = true;
            PickUpApple();
            
        }

        if ((other.CompareTag("stash")) && (hasApple) && (other.GetComponent<Stash>().stashID == team))
        {
            Debug.Log("player brought apple to stash");
            hasApple = false;
            DropApple();
            GameSession.AddToScore(1, team);
            Debug.Log("point obtained");
            //playerScore++;
        }
    }

    void Move(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        playerrb.velocity = movement * 5f;   
    }


    void PickUpApple()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2f;
        Quaternion spawnRotation = Quaternion.identity;

        apple = Instantiate(applePrefab, spawnPosition, spawnRotation, transform);
        Debug.Log("apple instantiated");
    }

    //destroy the apple object
    void DropApple()
    {
        Destroy(apple);
        Debug.Log("apple destroyed");
    }



}
