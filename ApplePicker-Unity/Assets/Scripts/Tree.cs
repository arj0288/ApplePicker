/*
 * Created by: ALex Jenkins
 * Date Created: 1/31/22
 * 
 * Last Edited: N/A
 * Last Edited By: N/A
 * 
 * Description: Controls tree movement and apple spawning
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float LeftAndRightEdge = 10f;
    public float ChanceToTurnDirection = .05f;
    public float SecondsBetweenAppleDrops =1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", SecondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //Move every frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //tree turn 'round
        /*if (pos.x < -LeftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x>LeftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }*/

        //Compiled into one if statement
        if(Mathf.Abs(pos.x)>LeftAndRightEdge)
        {
            speed *= -1;
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < ChanceToTurnDirection)
        {
            speed *= -1;
        }
    }
}
