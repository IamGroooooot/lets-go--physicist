using UnityEngine;
using UnityEngine.SceneManagement;

public class JHOnButtonClicked : MonoBehaviour
{
    GameObject _Pause;
    GameObject _Clear;
    const int MAX_STAGE_BUILD_ID = 5;
    const int MIN_STAGE_BUILD_ID = 2;
    private void Start()
    {
        _Pause = transform.Find("Panels").Find("PausePanel").gameObject;
        _Pause.SetActive(false);
        _Clear = transform.Find("Panels").Find("ClearPanel").gameObject;

        if (SceneManager.GetActiveScene().buildIndex >= MAX_STAGE_BUILD_ID)
        {
            transform.Find("Panels").Find("ClearPanel").Find("Buttons").Find("Next").gameObject.SetActive(false);
            transform.Find("Panels").Find("PausePanel").Find("Buttons").Find("Next").gameObject.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex <= MIN_STAGE_BUILD_ID)
        {
            transform.Find("Panels").Find("ClearPanel").Find("Buttons").Find("Prev").gameObject.SetActive(false);
            transform.Find("Panels").Find("PausePanel").Find("Buttons").Find("Prev").gameObject.SetActive(false);

        }
    }

    /// <summary>
    /// 정지 버튼 
    /// </summary>
    public void OnClick_Pause()
    {
        if (_Pause == null)
        {
            Debug.Log("Error - Pause 패널 어디감?");
        }

        Time.timeScale = 0;
        Debug.Log("is Paused, TimeScale set to " + Time.timeScale.ToString());
        _Pause.SetActive(true);
    }

    /// <summary>
    /// 다시 시작 버튼
    /// </summary>
    public void OnClick_Restart()
    {
        Time.timeScale = 1;
        Debug.Log("is Restarted, TimeScale set to " + Time.timeScale.ToString());
        Debug.Log("초기화시켜 줘야 됨");
        _Pause.SetActive(false);
        _Clear.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

    /// <summary>
    /// 일시 정지 해제 버튼
    /// </summary>
    public void OnClick_Resume()
    {
        Time.timeScale = 1;
        Debug.Log("is Resumed, TimeScale set to " + Time.timeScale.ToString());
        _Pause.SetActive(false);
    }

    /// <summary>
    /// 스태이지 선택으로 넘어가는 버튼
    /// </summary>
    public void OnClick_SlectStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectStage");
    }

    /// <summary>
    /// 다음 스태이지 선택 버튼
    /// </summary>
    public void OnClick_NextStage()
    {
        Time.timeScale = 1;
        //다음 씬 있는지 확인해야됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// 이전 스태이지 선택 버튼
    /// </summary>
    public void OnClick_PrevStage()
    {
        Time.timeScale = 1;
        //이전 씬 있는지 확인해야됨
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
