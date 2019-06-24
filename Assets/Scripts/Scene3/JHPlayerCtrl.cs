using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어에 대한 스크립트
/// </summary>
[RequireComponent(typeof(JHNavAgentCtrl))]  //JHPlayerMoter가 없으면 달아준다
public class JHPlayerCtrl : MonoBehaviour
{
    // Electron을 인식하기 위한 마스크
    public LayerMask electronMask;

    // 플러스와 마이너스 전하를 나타내는 메터리얼
    public Material electronBlue;
    public Material electronRed;

    //메인 카메라
    Camera cam;
    JHNavAgentCtrl motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<JHNavAgentCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        // 정지 상태면 미실행
        if (Time.timeScale == 0)
        {
            return;
        }

        //우측 클릭(스마트폰 하나 클릭)하면 레이케스트 쏨
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 8, electronMask))
            {
                if (hit.collider.name.Contains("Electron"))
                {
                    //Debug.Log("Changed Mat. of " + hit.collider.name + " " + hit.collider.GetComponent<MeshRenderer>().material.name);
                    if (hit.collider.GetComponent<MeshRenderer>().material.name == "Plus"|| hit.collider.GetComponent<MeshRenderer>().material.name == "Plus (Instance)")
                    {
                        hit.collider.GetComponent<MeshRenderer>().material = electronRed;
                    }
                    else
                    {
                        hit.collider.GetComponent<MeshRenderer>().material = electronBlue;

                    }

                }
            }
        }

        

        
    }
    
}
