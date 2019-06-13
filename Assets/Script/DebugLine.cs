using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class DebugLine : MonoBehaviour
{
    public Transform target;
    private LineRenderer lineRenderer;


    [SerializeField]
    private float minDistance;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(DrawRoutine());
    }

    IEnumerator DrawRoutine()
    {
        yield return new WaitUntil(() => target != null);
        Vector3 prevPos = target.position;
        lineRenderer.SetPosition(0, prevPos);
        lineRenderer.SetPosition(1, prevPos);
        while (true)
        {
            Vector3 nowPos = target.position;
            if ((nowPos - prevPos).sqrMagnitude > minDistance)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, nowPos);
                prevPos = nowPos;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
