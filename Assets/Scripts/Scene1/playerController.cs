using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Scene1의 player를 Control하기 위한 스크립트입니다.
/// </summary>
public class playerController : MonoBehaviour
{
    //Effect
    private GameObject effect;

    private GameObject mousePointA;
    private GameObject mousePointB;
    private GameObject arrow;
    private GameObject circle;
    private GameObject target;

    //calc distance
    private float currentdistance;
    public float maxdistance = 3f;
    private float safeSpace;
    private float shootpower;

    //이겼을 때 띄울 캡버스
    private GameObject clearCanvas;

    private Vector3 shootDirection;

    Rigidbody t_Rigidbody;
    bool shot=false;

    private void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        circle = GameObject.FindGameObjectWithTag("Circle");
        target = GameObject.FindGameObjectWithTag("Target");
        shot = false;
    }

    private void Start()
    {
        effect = GameObject.Find("Target").transform.GetChild(1).gameObject;
        //Clear 패널 가져오기
        clearCanvas = GameObject.Find("Panels").transform.GetChild(2).gameObject;
        if (Setting.SoundOn)
        {
            Camera.main.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().enabled = true;

        }
    }

    private void OnMouseDrag()
    {
        currentdistance = Vector3.Distance(mousePointA.transform.position, transform.position);

        //Clamp해줌
        if (currentdistance <= maxdistance)
        {
            safeSpace = currentdistance;
        }
        else
        {
            safeSpace = maxdistance;
        }

        doArrowAndCirclestuff();
        //calc power and direction
        shootpower = Mathf.Abs(safeSpace) * 6.3f;

        t_Rigidbody = target.GetComponent<Rigidbody>();
        t_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;

        Vector3 dimxy = mousePointA.transform.position - transform.position;
        float difference = dimxy.magnitude;
        mousePointB.SetActive(true);
        mousePointB.transform.position = transform.position + ((dimxy / difference) * currentdistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, mousePointB.transform.position.y, -0.5f);

        shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);
        //마우스를 Drag했을 때의 (월드상의) 텍스트를 띄운다
        _3DTextCtrl.instance.MsgOnDragStart();
    }


    private void OnMouseUp()
    {
        arrow.GetComponent<Renderer>().enabled = false;
        circle.GetComponent<Renderer>().enabled = false;
        shot = true;
        //발사하면 떨어지게
        t_Rigidbody.constraints = RigidbodyConstraints.None;
        t_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        Vector3 push = shootDirection * shootpower * -1;
        GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
        mousePointB.SetActive(false);

        effect.SetActive(false);
        //공을 던졌을 때의 사운드를 재생한다.
        if(Setting.SoundOn)
            GameObject.Find("throwBallSound").GetComponent<AudioSource>().Play();
    }


    private void doArrowAndCirclestuff()
    {
        arrow.GetComponent<Renderer>().enabled = true;
        circle.GetComponent<Renderer>().enabled = true;

        //calc position
        if (currentdistance <= maxdistance)
        {
            arrow.transform.position = new Vector3((2 * transform.position.x) - mousePointA.transform.position.x, (2 * transform.position.y) - mousePointA.transform.position
                .y, -1.5f);
        }
        else
        {
            Vector3 dimxy = mousePointA.transform.position - transform.position;
            float difference = dimxy.magnitude;
            arrow.transform.position = transform.position + ((dimxy / difference) * maxdistance * -1);
            arrow.transform.position = new Vector3(arrow.transform.position.x, arrow.transform.position.y, -1.5f);

        }

        circle.transform.position = transform.position + new Vector3(0, 0, 0.05f);
        Vector3 dir = mousePointA.transform.position - transform.position;
        float rot;
        if(Vector3.Angle(dir, transform.forward) > 90)
        {
            rot = Vector3.Angle(dir, transform.right);
        }
        else
        {
            rot = Vector3.Angle(dir, transform.right) * -1;
        }
        arrow.transform.eulerAngles = new Vector3(0, 0, rot);

        float scaleX = Mathf.Log(1 + safeSpace / 2, 2) * 2.2f;
        float scaleY = Mathf.Log(1 + safeSpace / 2, 2) * 2.2f;

        arrow.transform.localScale = new Vector3(1 + scaleX, 1 + scaleY/2, 0.001f);
        circle.transform.localScale = new Vector3(1 + scaleX, 1 + scaleY, 0.001f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {   //원숭이 맞춘 경우
            Debug.Log("원숭이 맞춤");
            //게임 승리 창 띄우기
            clearCanvas.gameObject.SetActive(true);
            //원숭이 Destroy
            Destroy(collision.gameObject);
            //원숭이 죽었을 때의 사운드 재생
            if (Setting.SoundOn)
                GameObject.Find("hitSound").GetComponent<AudioSource>().Play();
        }
        if (target == null)
        {   //원숭이가 없는 경우
            return;
        }
        if(shot && collision.gameObject.tag == "Floor")
        {   //공을 쏘았고 공이 바닥에 떨어진 경우
            //원숭이 죽임(오류 방지)
            Destroy(target);
            //게임 오버 코루틴 시작!
            StartCoroutine(gameOver());
            shot = false;
        }
    }
    //0.5초 기다린 후에 게임 오버창을 띄우고 게임오버 사운드를 실행합니다.
    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Panels").transform.GetChild(1).gameObject.SetActive(true);
        if (Setting.SoundOn)
            GameObject.Find("notHitSound").GetComponent<AudioSource>().Play();
        //3초 후에 재시작한다.
        Restart_3sec.instance.DoRestartCounting();
    }
    
}
