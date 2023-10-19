using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int current_health;
    public int max_health;
    //public HealthBar health_bar;
    void Start()
    {
        current_health = max_health;
    }

    void Update()
    {
        if (current_health < 0)
        {
            current_health = 0;
        }


        if (gameObject.tag == "Player")
        {
            if (current_health == 0)
            {
                //TP to tavern
            }
        }
        else
        {
            if (current_health == 0)
            {
                //play death animation
                //StartCoroutine(Timer(int?))
                // define IEnumerator Timer(int)
                //  yield return new WaiForSeconds(int)
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Player")
        {
            if (collision.collider.gameObject.CompareTag("Sword"))
            {
                DamagePlayer(20);
            }
        }
        else if (gameObject.tag == "Ennemy")
        {
            if (collision.collider.gameObject.CompareTag("Sword"))
            {
                DamagePlayer(20);
            }
        }
    }


    public void DamagePlayer(int damage)
    {
        current_health -= damage;
    }
}


/*{
    public int curHealth = 0;
public int maxHealth = 100;
public HealthBar healthBar;
void Start()
{
    curHealth = maxHealth;
}
voidUpdate()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        DamagePlayer(10);
    }
}

public void DamagePlayer(int damage)
{
    curHealth -= damage;

    healthBar.SetHealth(curHealth);
}
}*/