using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3DTextCtrl : MonoBehaviour
{
    public static _3DTextCtrl instance;
    
    //3D 텍스트
    private TextMesh textMesh;
    private void Awake()
    {
        //싱글톤
        instance = this;
        //자식의 3D 텍스트 가져오기
        textMesh = transform.GetChild(0).GetComponent<TextMesh>();
    }

    //마우스 터치 시작했을 때의 변화될 텍스트
    public void MsgOnDragStart()
    {
        textMesh.text = "<b>원숭이</b>를 맞추려면\n어디를 조준해야\n될까요?";
    }

   
}
