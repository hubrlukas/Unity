using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if ( player == null )
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if ( playerObj != null )
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if ( player != null ) navMeshAgent.SetDestination(player.position);
    }
}
