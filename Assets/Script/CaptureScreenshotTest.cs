﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CaptureScreenshotTest : MonoBehaviour {

    static RawImage img = null;
    static string filepath = null;
    static string filename = "myimage.png";
	// Use this for initialization
	void Start () {
        if (!img)
        {
            img = GameObject.FindObjectOfType<RawImage>();
        }
        filepath = Application.persistentDataPath + "/" + filename;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadImage()
    {
        byte[] data = File.ReadAllBytes(filepath);
        Texture2D texture = new Texture2D(1,1);
        texture.LoadImage(data);
        img.texture = texture;
    }

    public void captureImage()
    {
        string savepath = Application.isMobilePlatform ? filename : filepath;
        Application.CaptureScreenshot(savepath);
        print(Application.persistentDataPath);
    }
}
