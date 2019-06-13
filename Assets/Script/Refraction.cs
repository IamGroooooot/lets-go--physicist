using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refraction : MonoBehaviour
{
    private GameObject mousePointA;
    private GameObject mousePointB;
    private GameObject arrow;
    private GameObject circle;
    private GameObject target;
    public GameObject player;

    //calc distance
    private float currentdistance;
    public float maxdistance = 3f;
    private float safeSpace;
    private float shootpower;
    private float refract_shootpower;
    //굴절률
    private float n1 = 1;
    private float n2 = Mathf.Sqrt(3);

    private float Angle_between;
    private float refract_angle;

    private GameObject clearCanvas;

    private Vector3 shootDirection;
    private Vector3 startPosition;
    private Vector3 push;
    private Vector3 normalLine;
    private Vector3 shootLine;
    private Vector3 refractLine;
    private Vector3 refractLine2;
    private Vector3 savePosition;

    Rigidbody t_Rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        circle = GameObject.FindGameObjectWithTag("Circle");
        target = GameObject.FindGameObjectWithTag("Target");
        startPosition = player.transform.position;
        t_Rigidbody = GetComponent<Rigidbody>();
        // criticalAngle = Mathf.Acos(n1 / n2);
    }

    private void Start()
    {
        clearCanvas = GameObject.Find("Panels").transform.GetChild(2).gameObject;
    }

    private void OnMouseDrag()
    {
        currentdistance = Vector3.Distance(mousePointA.transform.position, transform.position);

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
        shootpower = Mathf.Abs(safeSpace) * 1;
        //굴절시 속도 변화
        refract_shootpower = shootpower * n1 / n2;


        Vector3 dimxy = mousePointA.transform.position - transform.position;
        float difference = dimxy.magnitude;
        mousePointB.SetActive(true);
        mousePointB.transform.position = transform.position + ((dimxy / difference) * currentdistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, mousePointB.transform.position.y, -0.5f);

        Debug.Log(mousePointA.transform.position);
        shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);

    }



    private void OnMouseUp()
    {
        arrow.GetComponent<Renderer>().enabled = false;
        circle.GetComponent<Renderer>().enabled = false;

        //발사하면 떨어지게

        push = shootDirection * shootpower * -1;
        GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
        mousePointB.SetActive(false);
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
        if (Vector3.Angle(dir, transform.forward) > 90)
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

        arrow.transform.localScale = new Vector3(1 + scaleX, 1 + scaleY / 2, 0.001f);
        circle.transform.localScale = new Vector3(1 + scaleX, 1 + scaleY, 0.001f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Refraction")
        {
            Debug.Log("맞음");
            savePosition = player.transform.position;
            normalLine = savePosition - other.transform.position;
            shootLine = startPosition - player.transform.position;
            Debug.Log(normalLine);
            Debug.Log(shootLine);
            //입사각
            Angle_between = Vector3.Angle(normalLine, shootLine);
            //굴절각
            refract_angle = Mathf.Asin(n1 * Mathf.Sin(Angle_between * Mathf.Deg2Rad) / n2) * Mathf.Rad2Deg;
            //굴절되는 방향이 반대인 경우가 있으므로 if문으로 체크
            if (startPosition.y < savePosition.y)
                refractLine = new Vector3(-1 * normalLine.x, -1 * normalLine.y, normalLine.z) + new Vector3(normalLine.y * Mathf.Tan(refract_angle * Mathf.Deg2Rad), normalLine.x * Mathf.Tan(refract_angle * Mathf.Deg2Rad) * -1, normalLine.z);
            else
                refractLine = new Vector3(-1 * normalLine.x, -1 * normalLine.y, normalLine.z) + new Vector3(-1 * normalLine.y * Mathf.Tan(refract_angle * Mathf.Deg2Rad), normalLine.x * Mathf.Tan(refract_angle * Mathf.Deg2Rad), normalLine.z);
            //벡터 설정
            GetComponent<Rigidbody>().AddForce(push * -1, ForceMode.Impulse);
            GetComponent<Rigidbody>().AddForce(refractLine * refract_shootpower, ForceMode.Impulse);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("나옴");
        //굴절률이 다른 원 영역에서 나올 때 다시 굴절하는 각
        if (startPosition.y < savePosition.y)
            refractLine2 = new Vector3(refractLine.x, refractLine.y, refractLine.z) + new Vector3(refractLine.y * Mathf.Tan((Angle_between - refract_angle) * Mathf.Deg2Rad), -1 * refractLine.x * Mathf.Tan((Angle_between - refract_angle) * Mathf.Deg2Rad), refractLine.z);
        else
            refractLine2 = new Vector3(refractLine.x, refractLine.y, refractLine.z) + new Vector3(refractLine.y * Mathf.Tan((Angle_between - refract_angle) * Mathf.Deg2Rad) * -1, refractLine.x * Mathf.Tan((Angle_between - refract_angle) * Mathf.Deg2Rad), refractLine.z);


        //벡터 재설정
        GetComponent<Rigidbody>().AddForce(refractLine * refract_shootpower * -1, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(refractLine2 * shootpower, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("dd");
            clearCanvas.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        else
        {

        }


    }

}
