using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiveController : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    public int score = 0;
    bool invencible;

    public enum DeathMode { Teleport, ReloadScene, Destory }
    public DeathMode death_mode;
    public Transform respawn;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
    }

    public void Damage(int damage = 1, bool IgnoreInvencible = false)
    {
        if (!invencible || IgnoreInvencible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Corutine());
            if (lifes_current <=0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Debug.Log("He muerto");
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScene:

                break;
            case DeathMode.Destory:
                Destroy(gameObject);
                break;

            default:
                break;
        }
    }
    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            score++;
        }
        else if(other.tag == "Finish")
        {
            Debug.Log("Has ganado...");
            Application.Quit();
        }
    }

}
