using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variable Instantiation
    [SerializeField] Color32 hasAppleColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noAppleColor = new Color32(1, 1, 1, 1);
    [SerializeField] public float enemySpeed = 2f;

    public Rigidbody2D enemyRB;
    SpriteRenderer enemySR;

    public GameObject applePrefab;
    private GameObject apple;
    public GameObject target;

    private GameObject[] stashTargets;
    private GameObject[] pitTargets;
    public int team;
    //public int score=0;

    private bool has_attack = false;

    private bool hasApple = false;

    private bool AppleOnField = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get the enemy RB and SR Components from the scene
        enemyRB = GetComponent<Rigidbody2D>();
        enemySR = GetComponent<SpriteRenderer>();

        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {   

        if (target == null)
        {
            FindTarget();
        } 

        else
        {
            MoveTowardsTarget();
        }
        
    }

    //code for when enemy collides with another collider.  
    void OnTriggerEnter2D(Collider2D other) //other is the other colliders game object
    {
       if((other.CompareTag("pit")) && (!hasApple))
        {
            //Debug.Log("enemy picked up apple");
            hasApple = true;
            //enemySR.color = hasAppleColor;
            PickUpApple();
            has_attack = true;
            target = null;
            //transform.GetChild(0).GetComponent<Apple>().appleRB.IsSleeping = true;
        }

       if((other.CompareTag("stash")) && (hasApple))
        {
            //Debug.Log("enemy brought apple to stash");
            hasApple = false;
            //enemySR.color = noAppleColor;
            DropApple();
            GameSession.AddToScore(1, team);
            //score++;
            target = null;
        }

       /*
        
        if ((other.CompareTag("enemy")) && (has_attack) && (other.GetComponent<Enemy>().team !=team))
        {
            //Debug.Log("enemy attacked another enemy");
            has_attack = false;
            //enemySR.color = noAppleColor;
            target = null;
            if (other.GetComponent<Enemy>().hasApple)
            {
               // other.transform.GetChild(0).GetComponent<Apple>().onAttacked();
                other.GetComponent<Enemy>().enemyRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
                other.GetComponent<Enemy>().hasApple = false;
                other.GetComponent<Enemy>().AppleOnField = true;
            }
            else
            {
                other.GetComponent<Enemy>().enemyRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }
        }

       */
    }


    void FindTarget()
    {
        //Create lists of both stash and pit objects
        stashTargets = GameObject.FindGameObjectsWithTag("stash");
        pitTargets = GameObject.FindGameObjectsWithTag("pit");
        
        //If the enemy has an apple, match the stashID to the team, then go to that stash
        if(hasApple){
            for (int i=0; i<stashTargets.Length;i++){
                if (stashTargets[i].GetComponent<Stash>().stashID == team){
                    target = stashTargets[i];
                    //Debug.Log("found stash target");
                    break;
                }
            }
        }
        //If the enemy doesn't have an apple, match the pitID to the team, then go to that pit
        else{
            for (int i=0; i<pitTargets.Length;i++){
                if (pitTargets[i].GetComponent<Ballpit>().bpID == team){
                    target = pitTargets[i];
                    //Debug.Log("found pit target");
                    break;
                }
            }
        }
    }

    //Move towards pit or stash
    void MoveTowardsTarget()
    {
        Vector3 targetPos = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        enemyRB.MovePosition(targetPos);
        //Debug.Log("moving");
    }


    void PickUpApple()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2f; //spawns it slightly in front of the enemy and makes it a child of enemy
        Quaternion spawnRotation = Quaternion.identity;

        apple = Instantiate(applePrefab, spawnPosition, spawnRotation, transform);
        //Debug.Log("apple instantiated");
    }

    //destroy the apple object
    void DropApple()
    {
        Destroy(apple);
        //Debug.Log("apple destroyed");
    }


}
