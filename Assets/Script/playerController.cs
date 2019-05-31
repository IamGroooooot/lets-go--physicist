using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
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

    public Canvas clearCanvas;

    private Vector3 shootDirection;

    Rigidbody t_Rigidbody;

    // Start is called before the first frame update
    private void Awake()
    {
        mousePointA = GameObject.FindGameObjectWithTag("PointA");
        mousePointB = GameObject.FindGameObjectWithTag("PointB");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        circle = GameObject.FindGameObjectWithTag("Circle");
        target = GameObject.FindGameObjectWithTag("Target");
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
        shootpower = Mathf.Abs(safeSpace) * 6;

        t_Rigidbody = target.GetComponent<Rigidbody>();
        t_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;

        Vector3 dimxy = mousePointA.transform.position - transform.position;
        float difference = dimxy.magnitude;
        mousePointB.SetActive(true);
        mousePointB.transform.position = transform.position + ((dimxy / difference) * currentdistance * -1);
        mousePointB.transform.position = new Vector3(mousePointB.transform.position.x, mousePointB.transform.position.y, -0.5f);

        shootDirection = Vector3.Normalize(mousePointA.transform.position - transform.position);

    }



    private void OnMouseUp()
    {
        arrow.GetComponent<Renderer>().enabled = false;
        circle.GetComponent<Renderer>().enabled = false;

        //발사하면 떨어지게
        t_Rigidbody.constraints = RigidbodyConstraints.None;
        t_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        Vector3 push = shootDirection * shootpower * -1;
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

}
