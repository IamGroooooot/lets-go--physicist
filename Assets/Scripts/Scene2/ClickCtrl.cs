using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player를 끌어당기기 어려운 문제를 해결하기 위한 스크립트
/// </summary>
public class ClickCtrl : MonoBehaviour
{
    public static ClickCtrl instance;
    private void Awake()
    {
        instance = this;
    }

    //클릭전에는 클릭할 범위를 늘린다
    public void BeforeClick()
    {
        //콜라이더를 클릭하기 쉽도록 크게 만든다
        if (GetComponent<SphereCollider>()!=null)
        {
            GetComponent<SphereCollider>().radius = 3f;

        }

    }

    //클릭후에는 클릭할 범위를 복구시킨다
    public void AfterClick()
    {
        //콜라이더 크기 복구
        if (GetComponent<SphereCollider>() != null)
        {
            GetComponent<SphereCollider>().radius = 0.5f;

        }

    }
}
