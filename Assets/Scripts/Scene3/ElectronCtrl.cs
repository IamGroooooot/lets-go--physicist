using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronCtrl : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 dir = transform.position - other.transform.position;
            
            if(GetComponent<MeshRenderer>().material.name == "Plus" || GetComponent<MeshRenderer>().material.name == "Plus (Instance)")
            {
                dir = (-1)*dir;
            }

            float power = (GetComponent<SphereCollider>().radius - Vector3.Distance(transform.position, other.transform.position))/10;
            
            //Debug.Log("power: " + power);
            JHPlayerMoter.instance.AddVelocity(dir, power);
        }
    }
}
