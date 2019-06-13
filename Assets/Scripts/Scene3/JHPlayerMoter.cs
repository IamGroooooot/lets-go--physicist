using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JHPlayerMoter : MonoBehaviour
{
    public static JHPlayerMoter instance= null;

    float stopTimer = 0;

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
        // 3초 동안 멈추면 게임 오버
        if (agent.velocity == Vector3.zero)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer>=2f)
            {
                GameObject.Find("Panels").transform.GetChild(1).gameObject.SetActive(true);
                Restart_3sec.instance.DoRestartCounting();
                stopTimer = -3f;
            }
        }
        else
        {
            stopTimer = 0;
        }
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
