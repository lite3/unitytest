using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class AssetBuildTool : MonoBehaviour {
    
    [MenuItem("AssetBundles/Build Asset Bundles")]
    static void CreateAssetBundles()
    {
        //string outputPath = Application.dataPath + "/AssetBundles";
        string outputPath = "Assets/AssetBundles";
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        buildMap[0].assetBundleName = "cubeatlas";
        string[] enemyAssets = new[] { "Assets/Textures/cubeatlas.png" };
        buildMap[0].assetNames = enemyAssets;

        BuildPipeline.BuildAssetBundles(outputPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }

    [MenuItem("AssetBundles/LoadAssetBundle")]
    static void LoadAssetBundle()
    {
        string filepath = Application.dataPath + "/AssetBundles/cubeatlas";
        byte[] bytes = null;
        FileUtil.GetData(filepath, out bytes);
        // 不支持加载压缩的AssetBundle
        //AssetBundle ab = AssetBundle.CreateFromFile(filepath);
        // 支持加载压缩的AssetBundle
        AssetBundle ab = AssetBundle.CreateFromMemoryImmediate(bytes);
        string[] names = ab.GetAllAssetNames();
        print("names -----------");
        foreach(string name in names)
        {
            print(name);
            Texture2D texture = ab.LoadAsset<Texture2D>(name);
            
            print(name +":"+texture.format.ToString()+":"+texture.width);
        }
        ab.Unload(false);
    }

    [MenuItem("AssetBundles/LoadImage")]
    static void LoadImage()
    {
        string filepath = Application.dataPath + "/Textures/cubeatlas.png";

        byte[] bytes = null;
        FileUtil.GetData(filepath, out bytes);
        print("size:" + bytes.Length);
        Texture2D texture = new Texture2D(2, 2, TextureFormat.Alpha8, false);
        if (texture.LoadImage(bytes))
        {
            print("load image success");
            print("texture format:" + texture.format + "  " + texture.mipmapCount+"   " + texture.width + "   " + texture.height);
        }
    }

    [MenuItem("AssetBundles/Get Asset Bundle names")]
    static void GetNames()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
            Debug.Log("Asset Bundle: " + name);
    }
}

