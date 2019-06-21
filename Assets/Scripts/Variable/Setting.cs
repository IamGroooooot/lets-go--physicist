using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    GameObject setting_Panel;
    public static bool SoundOn=true;

    // Start is called before the first frame update
    void Start()
    {
        setting_Panel = GameObject.Find("Setting_Panel");
        if(setting_Panel!=null)
            setting_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingClicked()
    {
        if(setting_Panel.activeSelf!=true)
            setting_Panel.SetActive(true);
        else
            setting_Panel.SetActive(false);

    }
}
