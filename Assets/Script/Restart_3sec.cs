using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart_3sec : MonoBehaviour
{
    public static Restart_3sec instance = null;
    private Text timerCounter_txt;
    private void Awake()
    {
        instance = this;
    }

    public void DoRestartCounting()
    {
        int limit = 3;
        timerCounter_txt = this.transform.GetChild(1).GetComponent<Text>();
        StartCoroutine(threeSecondTimer(timerCounter_txt, limit));
    }

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
