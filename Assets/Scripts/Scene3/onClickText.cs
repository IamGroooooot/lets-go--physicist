using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClickText : MonoBehaviour
{
    public TextMesh explain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            explain.text = "제단을 향해 떠나보세요!";
        }
    }
}
