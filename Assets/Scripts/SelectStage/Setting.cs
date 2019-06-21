using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 설정을 위한 스크립트
/// </summary>
public class Setting : MonoBehaviour
{
    GameObject setting_Panel;
    public static bool SoundOn = true;

    // Start is called before the first frame update
    void Start()
    {
        setting_Panel = GameObject.Find("Setting_Panel");
        string savedSoundOn = JHGameVariableManager.instance.LoadStringVariable(GameDataEnum.VariableType.eSound);
        SoundOn = Convert.ToBoolean(savedSoundOn);
            
        if (setting_Panel!=null)
            setting_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //설정 버튼 눌렀을 때
    public void OnSettingClicked()
    {
        if(setting_Panel.activeSelf!=true)
            setting_Panel.SetActive(true);
        else
            OnSettingPanelClicked();
    }

    public void OnSettingPanelClicked()
    {
        gameObject.SetActive(false);
        //나갈 때 save
        JHGameVariableManager.instance.SaveVariable(GameDataEnum.VariableType.eSound, SoundOn.ToString());
    }
}
