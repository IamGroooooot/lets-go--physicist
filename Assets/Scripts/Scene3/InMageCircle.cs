using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InMageCircle : MonoBehaviour
{
    private GameObject clearCanvas;
    private GameObject pauseCanvas;
    private GameObject gameoverCanvas;
    GameObject minimap;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        clearCanvas = GameObject.Find("Panels").transform.GetChild(2).gameObject;
        gameoverCanvas = GameObject.Find("Panels").transform.GetChild(1).gameObject;
        pauseCanvas = GameObject.Find("Panels").transform.GetChild(0).gameObject;
        minimap = GameObject.FindGameObjectWithTag("Minimap");
    }
    private void Update()
    {
        if (clearCanvas.gameObject.activeSelf || gameoverCanvas.gameObject.activeSelf|| pauseCanvas.gameObject.activeSelf)
        {
            minimap.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
        }
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
