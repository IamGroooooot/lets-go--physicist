using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMageCircle : MonoBehaviour
{
    private GameObject clearCanvas;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        clearCanvas = GameObject.Find("Panels").transform.GetChild(2).gameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                Debug.Log("Stage3 Clear");
                clearCanvas.gameObject.SetActive(true);
                timer = 0;
            }
        }
    }
}
