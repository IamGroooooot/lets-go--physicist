using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공 궤적을 그리는 스크립트
/// </summary>
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

    //라인 렌더러로 궤적을 그립니다.
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
                lineRenderer.material.color = Color.black;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
