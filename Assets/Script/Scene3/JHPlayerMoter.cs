using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JHPlayerMoter : MonoBehaviour
{
    public static JHPlayerMoter instance= null;

    private void Awake()
    {
        instance = this;
    }

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void AddVelocity(Vector3 direction, float power)
    {
        //Debug.Log("vel to " + direction.x + direction.y + direction.z);
        direction = Vector3.Normalize(direction);
        
        power = Mathf.Abs(power);
        agent.velocity = new Vector3(agent.velocity.x + direction.x * power, agent.velocity.y + direction.y * power, agent.velocity.z+ direction.z * power);//direction*power;
    }
}
