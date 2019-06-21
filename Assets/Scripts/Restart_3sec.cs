using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//3초 후에 재시작하는 스크립트
public class Restart_3sec : MonoBehaviour
{
    public static Restart_3sec instance = null;
    private Text timerCounter_txt;
    int limit = 3;

    private void Awake()
    {
        instance = this;
    }

    //카운터를 Set
    public void DoRestartCounting()
    {
        timerCounter_txt = this.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        StartCoroutine(threeSecondTimer(timerCounter_txt, limit));
    }

    //3초를 초당 1마이너스하고 3초후에 리스타트
    public IEnumerator threeSecondTimer(Text timer,int limit)
    {
        while (true)
        {
            timer.text = limit.ToString();
            yield return new WaitForSeconds(1f);
            if (limit <= 1)
            {
                break;
            }
            limit--;
        }
        JHOnButtonClicked.instance.OnClick_Restart();
    }
}
