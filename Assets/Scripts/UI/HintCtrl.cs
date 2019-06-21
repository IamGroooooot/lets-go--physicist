using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HintCtrl : MonoBehaviour
{
    int currentBuildId;
    GameObject hintPanel;
    Sprite S1_image; 
    Sprite S2_image; 
    Sprite S3_image; 
    Sprite S4_image; 

    // Start is called before the first frame update
    void Start()
    {
        //현재 씬의 빌드 Id
        currentBuildId = SceneManager.GetActiveScene().buildIndex;
        hintPanel = GameObject.Find("Hint"). transform.GetChild(0).gameObject;
        S1_image = Resources.Load<Sprite>("Images/Notes/1");
        S2_image = Resources.Load<Sprite>("Images/Notes/2");
        S3_image = Resources.Load<Sprite>("Images/Notes/3");
        S4_image = Resources.Load<Sprite>("Images/Notes/4.jpg");

        if ((currentBuildId-1) == 1)
        {
            hintPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = S1_image;
        }
        else if ((currentBuildId - 1) == 2)
        {
            hintPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = S2_image;
        }
        else if ((currentBuildId - 1) == 3)
        {
            hintPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = S3_image;
        }
        else if ((currentBuildId - 1) == 4)
        {
            hintPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = S4_image;
        }
        else 
        {
            hintPanel.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite =null;
        }
    }

    public void onClickHint()
    {
        if (hintPanel == null)
        {
            Debug.Log("Error - Hint 패널 어디감?");
        }
        Time.timeScale = 1;
        hintPanel.SetActive(false);
    }
}
