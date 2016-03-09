using UnityEngine;
using System.Collections;

public class MouseEventTest : MonoBehaviour {


    void Reset()
    {
        print("MouseEvent Reset");
    }
    void Awake()
    {
        print("MouseEvent Awake");
    }
	// Use this for initialization
	void Start () {
        print("MouseEvent Start");
	}

	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseEnter()
    {
        print("OnMouseEnter");
    }
    void OnMouseOver()
    {
        // 当鼠标在目标上时，会每帧都触发
        print("OnMouseOver");
    }
    void OnMouseExit()
    {
        print("OnMouseExit");
    }
    void OnMouseDown()
    {
        print("OnMouseDown");
    }
    void OnMouseUp()
    {
        print("OnMouseUp");
    }

    void OnMouseDrag()
    {
        // 当鼠标在目标上按住,弹起鼠标之前,(不论是否在目标上)会每帧都触发
        print("OnMouseDrag");
    }
}
