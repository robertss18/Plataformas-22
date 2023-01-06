using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Trigger : MonoBehaviour
{
    public bool grounded;
    public void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }
}
