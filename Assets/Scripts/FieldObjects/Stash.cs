using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public int stashID;
    AudioSource stashAScheer;
    // Start is called before the first frame update
    void Start()
    {
        stashAScheer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cheer(){
        stashAScheer.Play();
    }
}
