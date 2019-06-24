using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 설정을 위한 스크립트
/// </summary>
public class Setting : MonoBehaviour
{
    GameObject setting_Panel;
    public static bool SoundOn = true;
  
    [SerializeField]
    private GameObject sound;
    
    // Start is called before the first frame update
    Sprite soundOnImage, muteImage;
    void Start()
    {
        //이미지 가져오기
        muteImage = Resources.Load<Sprite>("Images/UI_Images/Icons_UI/Icons_grayscale/22");
        soundOnImage = Resources.Load<Sprite>("Images/UI_Images/Icons_UI/Icons_grayscale/21");
        //설정 패널 가져오기
        setting_Panel = GameObject.Find("Setting_Panel");
        //세이브 파일 불러오기
        SoundOn = JHGameVariableManager.instance.LoadBoolVariable(GameDataEnum.VariableType.eSound);
        //세이브한 사운드 설정 불러오기
        if (SoundOn)
        {
            sound.GetComponent<Image>().sprite = soundOnImage;
        }
        else
        {
            sound.GetComponent<Image>().sprite = muteImage;
        }
        //패널 비활성화
        if (setting_Panel!=null)
            setting_Panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //사운드 클릭
    public void OnSoundBtnClicked()
    {
        if (sound.GetComponent<Image>().sprite.name == "22")
        {
            sound.GetComponent<Image>().sprite = soundOnImage;
            SoundOn = true;
            Debug.Log("Muted-> On, saved "+ SoundOn);
            JHGameVariableManager.instance.SaveVariable(GameDataEnum.VariableType.eSound, SoundOn);
        }
        else
        {
            sound.GetComponent<Image>().sprite = muteImage;
            SoundOn = false;
            Debug.Log("On -> Mute, saved " + SoundOn);
            JHGameVariableManager.instance.SaveVariable(GameDataEnum.VariableType.eSound, SoundOn);
        }
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

        if (setting_Panel != null)
            setting_Panel.SetActive(false);
       
    }
}
