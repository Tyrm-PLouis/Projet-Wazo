using UnityEngine;

public class Range_Collider : MonoBehaviour
{
    public Kobold _kobold;
    public Transform Player;
    private void Start()
    {

    }

    private void Update()
    {
        Aggro();
    }

    private void OnTriggerStay(Collider other)
    {
        if ("Player" == other.tag)
        {
            Player = other.GetComponent<Transform>();
        }
        else
        {
            Player = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ("Player" == other.tag)
        {
            Player = null;
        }
    }

    private bool PlayerInSight()
    {
        return this.Player != null;
    }

    public void Aggro()
    {
        if (PlayerInSight())
        {
            if (Vector3.Distance(transform.position, Player.position) < 100f)
            {
                MoveToPlayer();
            }
        }
    }

    private void MoveToPlayer()
    {
        Transform target = Player;

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * _kobold.speed);
    }

}