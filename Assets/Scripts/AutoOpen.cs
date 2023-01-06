using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpen : MonoBehaviour
{

    public Transform Laser, Open, Close, Item;
    public float speed;
    bool isEnter;

    void Update()
    {
        Laser.transform.position = Vector2.MoveTowards(Laser.transform.position, (isEnter && Item.childCount == 0) ? Open.position : Close.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isEnter = false;
        }
    }
}
