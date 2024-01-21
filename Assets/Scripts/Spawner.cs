using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int team;
    public GameObject enemyPrefab;
    public int enemyCount;
    public int teamScore;

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemies(enemyPrefab, enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateEnemies(GameObject enemyPrefab, int numberofEnemies){
        for (int i=0;i<numberofEnemies;i++){
            GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(i,i,i), Quaternion.identity,transform);
            

            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.team = team;
            //enemy.team = team;
        }
    }
}
