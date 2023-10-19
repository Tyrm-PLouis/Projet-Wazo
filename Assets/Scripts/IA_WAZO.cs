using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_WAZO : MonoBehaviour
{
    public NavMeshAgent ai;     //main ia pour WAZO
    public Transform player;    //"transform" du joueur (attention! mettre le XR Rig!!)
    public Animator aiAnim;     //Anim Controller de Wazo
    private Vector3 dest;               //Variable tampon

    private bool started = false;

    private void Start()
    {

        ai.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (started)
        {
            ai.enabled = true;


            if (Random.value * 100 < 5)
            {
                dest = player.position + new Vector3(Random.value * 5, 0, Random.value * 5);
            }

            ai.destination = dest;

            if (ai.remainingDistance <= ai.stoppingDistance)
            {

                aiAnim.ResetTrigger("fly");
                while (ai.baseOffset > 0.5f)
                {
                    ai.baseOffset -= 0.2f;
                }
                aiAnim.SetTrigger("idle");

                dest = player.position;
            }
            else
            {
                aiAnim.ResetTrigger("idle");

                while (ai.baseOffset < 3f)
                {
                    ai.baseOffset += 0.2f;
                }
                aiAnim.SetTrigger("fly");
            }
        }

    }

    public void setStarted(bool val)
    {
        started = val;
    }
}
