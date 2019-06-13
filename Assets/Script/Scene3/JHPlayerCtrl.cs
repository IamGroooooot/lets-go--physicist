using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JHPlayerMoter))]
public class JHPlayerCtrl : MonoBehaviour
{
    public LayerMask movementMask;
    public LayerMask electronMask;

    public Material electronBlue;
    public Material electronRed;

    public bool ChangeMaterial= true;

    Camera cam;
    JHPlayerMoter motor;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<JHPlayerMoter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,100,movementMask))
            {
                Debug.Log("We hit "+ hit.collider.name+ " "+ hit.point);
                // Move  player to where we hit
                // motor.MoveToPoint(hit.point);
                // Stop Foucusing obj
            }

            if (!ChangeMaterial)
            {
                return;
            }

            if (Physics.Raycast(ray, out hit, 8, electronMask))
            {
                if (hit.collider.name.Contains("Electron"))
                {
                    Debug.Log("We Changed Mat. of " + hit.collider.name + " " + hit.collider.GetComponent<MeshRenderer>().material.name);
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
