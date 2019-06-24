using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JHGameVariableManager : MonoBehaviour
{
    public static JHGameVariableManager instance = null; // for singleton

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 타입 이넘값으로 값을 저장해준다.
    /// string value 전용
    /// </summary>
    public void SaveVariable(GameDataEnum.VariableType type, string value)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 변환한 값을 그대로 넣어주자.
        PlayerPrefs.SetString(key, value);
    }

    /// <summary>
    /// 타입 이넘값으로 값을 저장해준다.
    /// Int value 전용
    /// </summary>
    public void SaveVariable(GameDataEnum.VariableType type, int value)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 변환한 값을 그대로 넣어주자.
        PlayerPrefs.SetInt(key, value);
    }

    /// <summary>
    /// 타입 이넘값으로 값을 저장해준다.
    /// Float value 전용
    /// </summary>
    public void SaveVariable(GameDataEnum.VariableType type, float value)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 변환한 값을 그대로 넣어주자.
        PlayerPrefs.SetFloat(key, value);
    }

    /// <summary>
    /// 타입 이넘값으로 값을 저장해준다.
    /// Bool value 전용
    /// </summary>
    public void SaveVariable(GameDataEnum.VariableType type, bool value)
    {
        // 이넘값 변환
        string key = type.ToString();

        //Convert to int
        int savingValue;
        if (value)
        {
            savingValue = 1;
        }
        else
        {
            savingValue = 0;
        }
        // 변환한 값을 그대로 넣어주자.
        PlayerPrefs.SetInt(key, savingValue);
    }

    /// <summary>
    /// 타입 이넘값을 바탕으로 저장된 값을 불러온다.
    /// </summary>
    public string LoadStringVariable(GameDataEnum.VariableType type)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 불러오기
        string returnValue = PlayerPrefs.GetString(key);

        Debug.Log("LoadValue From //" + key + "// : //" + returnValue + "//");

        return returnValue;
    }

    /// <summary>
    /// 타입 이넘값을 바탕으로 저장된 값을 불러온다.
    /// </summary>
    public int LoadIntVariable(GameDataEnum.VariableType type)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 불러오기
        int returnValue = PlayerPrefs.GetInt(key);

        Debug.Log("LoadValue From //" + key + "// : //" + returnValue.ToString() + "//");

        return returnValue;
    }

    /// <summary>
    /// 타입 이넘값을 바탕으로 저장된 값을 불러온다.
    /// </summary>
    public bool LoadBoolVariable(GameDataEnum.VariableType type)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 불러오기
        int savedValue = PlayerPrefs.GetInt(key);

        //Convert to int
        bool returnValue;
        if (savedValue==1)
        {
            returnValue = true;
        }
        else
        {
            returnValue = false;
        }

        Debug.Log("LoadValue From //" + key + "// : //" + returnValue.ToString() + "//");

        return returnValue;
    }

    /// <summary>
    /// 타입 이넘값을 바탕으로 저장된 값을 불러온다.
    /// </summary>
    public float LoadFloatVariable(GameDataEnum.VariableType type)
    {
        // 이넘값 변환
        string key = type.ToString();

        // 불러오기
        float returnValue = PlayerPrefs.GetFloat(key);

        Debug.Log("LoadValue From //" + key + "// : //" + returnValue.ToString() + "//");

        return returnValue;
    }
}
