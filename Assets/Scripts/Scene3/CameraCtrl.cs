﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라를 제어하는 스크립트
/// </summary>
public class CameraCtrl : MonoBehaviour
{
    public GameObject[] CamSettingObjs;
    public Transform playerTxt;
    public Transform Txt1;
    public Transform target;
    //오프셋
    public Vector3 offset;
    //줌
    private static float currentZoom = 10;
    public float pitch = 1;
    public float zoomSpeed = 0.4f;
    public float minZoom= 5f;
    public float maxZoom= 15f;
    //회전
    public static float yawSpeed = 10f;
    private float currentYaw = 0;

    public static bool cameraProcessing=false;

    private void Start()
    {
        foreach (var item in CamSettingObjs)
        {
            item.SetActive(false);
        }
    }

    private void Update()
    {
        //카메라에 보이도록 Txt들을 회전시킨다
        playerTxt.LookAt(this.transform.position);
        Txt1.LookAt(this.transform.position);
    }

    // 카메라 제어할 명령어들은 LateUpdate에
    void LateUpdate()
    {
        //offset+Zoom을 적용한 카메라
        transform.position = target.position - offset * currentZoom;
        //Player를 향해서 카메라 방향 조절 
        transform.LookAt(target.position + Vector3.up * pitch);
        //카메라를 플레이어의 position을 기준으로 회전시킨다
        transform.RotateAround(target.position,Vector3.up, currentYaw);
    }

    public void OnZoomInClicked()
    {
        currentZoom -= zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }


    public void OnZoomOutClicked()
    {
        currentZoom += zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    //좌 회전 눌렀을 때
    public void OnYawLClicked()
    {
        currentYaw -= yawSpeed;
    }
    
    //우 회전 눌렀을 때
    public void OnYawRClicked()
    {
        currentYaw += yawSpeed;
    }

    //카메라 설정창 열기 버튼 눌렀을 때
    public void OnCamSettingBtnClicked()
    {
        if (CamSettingObjs[0].activeSelf)
        {
            Time.timeScale = 1;

            foreach (var item in CamSettingObjs)
            {
                item.SetActive(false);
            }
        }
        else
        {
            Time.timeScale = 0;
            foreach (var item in CamSettingObjs)
            {
                item.SetActive(true);
            }
        }
    }
}
