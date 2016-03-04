using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class AssetBuildTool : MonoBehaviour {
    
    
    [MenuItem("AssetBundles/Build Asset Bundles")]
    static void CreateAssetBundles()
    {
        AssetBundleBuild[] buildMap = new AssetBundleBuild[1];

        buildMap[0].assetBundleName = "cubeatlas";
        string[] enemyAssets = new[] { "Assets/Textures/cubeatlas.png" };
        buildMap[0].assetNames = enemyAssets;

        Directory.CreateDirectory(PathUtil.windowsStreamingAssetsPath);
        Directory.CreateDirectory(PathUtil.osxStreamingAssetsPath);
        Directory.CreateDirectory(PathUtil.androidStreamingAssetsPath);
        Directory.CreateDirectory(PathUtil.iosStreamingAssetsPath);

        BuildPipeline.BuildAssetBundles(PathUtil.windowsStreamingAssetsPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        BuildPipeline.BuildAssetBundles(PathUtil.osxStreamingAssetsPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
        BuildPipeline.BuildAssetBundles(PathUtil.androidStreamingAssetsPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.Android);
        BuildPipeline.BuildAssetBundles(PathUtil.iosStreamingAssetsPath, buildMap, BuildAssetBundleOptions.None, BuildTarget.iOS);
    }

    [MenuItem("AssetBundles/LoadAssetBundle")]
    static void LoadAssetBundle()
    {
        string filepath = PathUtil.streamingAssetsPath + "/cubeatlas";
        byte[] bytes = File.ReadAllBytes(filepath);
        // 不支持加载压缩的AssetBundle
        //AssetBundle ab = AssetBundle.CreateFromFile(filepath);
        // 支持加载压缩的AssetBundle
#if UNITY_5_3
        AssetBundle ab = AssetBundle.LoadFromMemory(bytes);
#else
        AssetBundle ab = AssetBundle.CreateFromMemoryImmediate(bytes);
#endif
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

        byte[] bytes = File.ReadAllBytes(filepath);
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
        print("AssetBundles/Get Asset Bundle names");
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
            print("Asset Bundle: " + name);
    }
}

