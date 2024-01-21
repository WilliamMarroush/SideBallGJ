using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingRun : MonoBehaviour
{
    public float bounceHeight=0.001f;
    public float bounceSpeed=0.5f;

    private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = startPosition + new Vector2(transform.position.x, startPosition.y + yOffset);
    }
}
