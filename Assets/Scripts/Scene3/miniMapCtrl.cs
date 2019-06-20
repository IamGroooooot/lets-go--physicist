using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 미니맵 움직임 스크립트
/// </summary>
public class miniMapCtrl : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // minmap카메라를 플레이어를 따라다니게 한다
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
    }
}
