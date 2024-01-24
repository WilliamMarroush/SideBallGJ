using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHSName : MonoBehaviour
{
    GameSession GS;
    public Text displayName;
    // Start is called before the first frame update
    void Start()
    {
        GS = FindObjectOfType<GameSession>();
        displayName.text = GS.GetName().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
