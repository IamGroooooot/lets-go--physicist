using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JHSceneManger : MonoBehaviour
{
    /// <summary>
    /// Move to Selection
    /// </summary>
    public void OnStart()
    {
        SceneManager.LoadScene("SelectStage");
    }

    /// <summary>
    /// Move to S1
    /// </summary>
    public void OnClickS1()
    {
        SceneManager.LoadScene("S1");
    }

    /// <summary>
    /// Move to S2
    /// </summary>
    public void OnClickS2()
    {
        SceneManager.LoadScene("S2");
    }

    /// <summary>
    /// Move to S3
    /// </summary>
    public void OnClickS3()
    {
        SceneManager.LoadScene("S3");
    }

    /// <summary>
    /// Move to S4
    /// </summary>
    public void OnClickS4()
    {
        SceneManager.LoadScene("S4");
    }

    /// <summary>
    /// Move to InGame Temp
    /// </summary>
    public void OnClickInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
