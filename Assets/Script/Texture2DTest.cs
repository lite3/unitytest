using UnityEngine;
using System.Collections;
using System.IO;

public class Texture2DTest : MonoBehaviour
{

    private Texture2D texture1 = null;
    private Texture2D texture2 = null;

    // Use this for initialization
    void Start()
    {

        StartCoroutine(LoadImageInAssetBundle());
        //texture2 = LoadImage("cubeatlas.png");

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadImageInAssetBundle()
    {
        string filename = "file://" + Application.dataPath + "/AssetBundles/cubeatlas";
        WWW www = new WWW(filename);
        yield return www;
        AssetBundle ab = www.assetBundle;
        foreach (string name in ab.GetAllAssetNames())
        {
            print("ab name: " + name);
            texture1 = ab.LoadAsset<Texture2D>(name);
            print("texture :" + texture1.name + "  " + texture1.format + "  " + texture1.mipmapCount + "   " + texture1.width + "   " + texture1.height);
            GetComponent<Renderer>().material.mainTexture = texture1;
        }
        ab.Unload(false);
        www.Dispose();
    }

    Texture2D LoadImage(string name)
    {
        byte[] buffer = File.ReadAllBytes(Application.dataPath + "/" + name);
        print("size:" + buffer.Length);
        Texture2D texture = new Texture2D(2, 2, TextureFormat.Alpha8, false);
        texture.name = name;
        if (texture.LoadImage(buffer))
        {
            print("load image success " + name);
            print("texture format:" + texture.format + "  " + texture.mipmapCount + "   " + texture.width + "   " + texture.height);

        }
        return texture;
    }

    void OnEnable()
    {
        //         print("onEnabled");
        //         texture1 = LoadImage("cubeatlas.png");
        //         texture2 = LoadImage("256.png");
    }

    void OnDisable()
    {
        //         print("onDisable");
        //         GameObject.DestroyImmediate(texture1, true);
        //         GameObject.DestroyImmediate(texture2, true);
        //         texture1 = null;
        //         texture2 = null;
    }
}
