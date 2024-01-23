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
    public GameObject fieldapplePrefab;
    public GameObject fieldapple;
    public GameObject apple;
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

        Vector3 ApplespawnPosition = transform.position + transform.forward * 2f; 
        Quaternion ApplespawnRotation = Quaternion.identity;
        apple = Instantiate(applePrefab, ApplespawnPosition, ApplespawnRotation, transform);
        apple.GetComponent<Apple>().appleSR.enabled = false;
        
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {   
        RunBounce();
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
            GameSession.AddToScore(1, team);  //adds points to mone of the enemies teams.  needs the team id so it adds points to the right team.  
            //score++;
            target = null;
        }



        if ((other.CompareTag("enemy")) && (has_attack)  && (other.GetComponent<Enemy>().team !=team))
        {
            has_attack = false;

            if (other.GetComponent<Enemy>().hasApple){

                other.transform.GetChild(0).GetComponent<Apple>().appleSR.enabled = false; //Turn off the Sprite renderer for enemy display apple
                other.GetComponent<Enemy>().on_Get_Attacked();
                //other.GetComponent<Enemy>().enemyRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse); //Add force to the enemy that was attacked
                
            }

            else{
                other.GetComponent<Enemy>().enemyRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);//Add force to the enemy that was attacked
            }
        }
       
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
        
        if (!hasApple && AppleOnField){
            target = fieldapple;
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

    void RunBounce(){
        if (enemyRB.velocity != Vector2.zero)
        {
        // Rotate the enemy back and forth around the z axis
        float rotationSpeed = 10f; // Adjust this value to your liking
        float rotationDirection = Mathf.Sin(Time.time * rotationSpeed);
        enemyRB.transform.rotation = Quaternion.Euler(0, 0, rotationDirection * 30); // Adjust the 45 to control the rotation range
        }
    }

    void PickUpApple()
    {
        apple.GetComponent<Apple>().appleSR.enabled = true;
    }

    //destroy the apple object
    void DropApple()
    {
        apple.GetComponent<Apple>().appleSR.enabled = false;
    }

    void on_Get_Attacked(){
        hasApple = false;
        AppleOnField = true;
        target = null;
        fieldapple = Instantiate(fieldapplePrefab, transform.position, Quaternion.identity);
        Vector2 throwDirection = Random.insideUnitCircle.normalized;

        //apple.GetComponent<ThrownApple>().appleRB.AddForce(throwDirection, ForceMode2D.Impulse);
        fieldapple.GetComponent<ThrownApple>().appleRB.transform.Translate(throwDirection, Space.World);
    }


}
