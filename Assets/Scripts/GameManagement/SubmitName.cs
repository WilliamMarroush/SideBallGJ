using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{
    public GameSession GS;
    public GameObject nameInput;
    public InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        GS = FindObjectOfType<GameSession>();
        nameInputField = nameInput.GetComponent<InputField>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void PassData(){
        
    }
    
}
