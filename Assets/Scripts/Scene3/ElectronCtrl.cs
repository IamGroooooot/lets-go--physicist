using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전하들이 어떻게 작용할지 작성한 스크립트
/// </summary>
public class ElectronCtrl : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 dir = transform.position - other.transform.position;
            
            if(GetComponent<MeshRenderer>().material.name == "Plus" || GetComponent<MeshRenderer>().material.name == "Plus (Instance)")
            {   //자신의 메터리얼의 종류로 척력을 작용할지 인력을 작용할지 판단한다
                dir = (-1)*dir;
            }

            //작용할 힘의 세기는 거리로 계산 (k*q1*q2/r^2)
            float power = (GetComponent<SphereCollider>().radius - Vector3.Distance(transform.position, other.transform.position))/10;

            //Debug.Log("power: " + power);
            JHNavAgentCtrl.instance.AddVelocity(dir, power);
        }
    }
}
