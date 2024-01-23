using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int team;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;
    public int enemyCount;
    public int teamScore;
    public bool isPlayerTeam;

    // Start is called before the first frame update
    void Start()
    {
        CreateEnemies(enemyPrefab, enemyCount);
        CreatePlayer(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemies(GameObject enemyPrefab, int numberofEnemies){
        for (int i=0;i<numberofEnemies;i++){
            GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(i,i,0), Quaternion.identity,transform);
            

            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.team = team;
            //enemy.team = team;
        }
    }

    void CreatePlayer(GameObject playerPrefab){
        if (isPlayerTeam){
            GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity,transform);
            Player playerScript = player.GetComponent<Player>();
            playerScript.team = team;
        }
    }

}
