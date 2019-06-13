using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3DTextCtrl : MonoBehaviour
{
    public static _3DTextCtrl instance;

    public TextMesh textMesh;
    private void Awake()
    {
        instance = this;
        textMesh = transform.GetChild(0).GetComponent<TextMesh>();
    }

    public void MsgOnDragStart()
    {
        textMesh.text = "<b>원숭이</b>를 맞추려면\n어디를 조준해야\n될까요?";
    }

   
}
