using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Color32 hasAppleColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noAppleColor = new Color32(1, 1, 1, 1);
    [SerializeField] public float enemySpeed = 2f;

    public Rigidbody2D enemyRB;
    SpriteRenderer enemySR;

    public GameObject applePrefab;
    private GameObject apple;
    public GameObject target;

    private bool hasApple = false;
    // Start is called before the first frame update
    void Start()
    {
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

    void OnTriggerEnter2D(Collider2D other)
    {
       if((other.CompareTag("pit")) && (!hasApple))
        {
            Debug.Log("enemy picked up apple");
            hasApple = true;
            //enemySR.color = hasAppleColor;
            PickUpApple();
            target = null;
        }

       if((other.CompareTag("stash")) && (hasApple))
        {
            Debug.Log("enemy brought apple to stash");
            hasApple = false;
            //enemySR.color = noAppleColor;
            DropApple();
            target = null;
        }
    }

    void FindTarget()
    {
        if(hasApple)
        {
            target = GameObject.FindWithTag("stash");
            Debug.Log("found stash target");
        }

        else if(!hasApple)
        {
            target = GameObject.FindWithTag("pit");
            Debug.Log("found pit target");
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 targetPos = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        enemyRB.MovePosition(targetPos);
        //Debug.Log("moving");
    }

    void PickUpApple()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2f;
        Quaternion spawnRotation = Quaternion.identity;

        apple = Instantiate(applePrefab, spawnPosition, spawnRotation, transform);
        Debug.Log("apple instantiated");
    }

    void DropApple()
    {
        Destroy(apple);
        Debug.Log("apple destroyed");
    }


}
