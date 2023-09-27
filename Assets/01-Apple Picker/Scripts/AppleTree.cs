using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftandRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirection = 0.1f;

    //Rate at which Apples will be instantiated 
    public float secondsBetweenAppleDrop = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrop);
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing Direction
        if (pos.x < -leftandRightEdge)
        {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftandRightEdge)
        {
            speed = -Mathf.Abs(speed); //Move left
        }
    }
    private void FixedUpdate()
    {
        //Changing Directions Randomly is now time-based because of FixedUpdate()
        if (Random.value < chanceToChangeDirection)
        {
            speed += -1; //Change direction
        }
    }
}
