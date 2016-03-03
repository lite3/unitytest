using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class TestMenuItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    [MenuItem("MyMenu/Test/TestChild")]
    static void ChildMenuItem()
    {
        print("ChildMenuItem MyMenu/Test/TestChild");
    }

    [MenuItem("MyMenu/Test", false)]
    static void DoMenuItem()
    {
        print("click MenuItem MyMenu/Test");
    }

    [MenuItem("MyMenu/Play", true)]
    static bool CheckMenuPlay()
    {
        return !EditorApplication.isPlaying;
    }

    [MenuItem("MyMenu/Play", false)]
    static void Play()
    {
        EditorApplication.isPlaying = true;
    }

    [MenuItem("MyMenu/Stop", true)]
    static bool CheckMenuStop()
    {
        return EditorApplication.isPlaying;
    }

    [MenuItem("MyMenu/Stop", false)]
    static void Stop()
    {
        EditorApplication.isPlaying = false;
    }

    //[MenuItem("MyMenu/Build Asset Bundles")]
    //static void DoCreateAssetBundles()
    //{
    //    // Put the bundles in a folder called "AssetBundles" within the Assets folder.
    //    print("xxxxxxxxxxxx"+UnityEditor.FileUtil.GetProjectRelativePath("Assets/AssetBundles"));
    //    print("applicationContentsPath: " + EditorApplication.applicationContentsPath);
    //    print("applicationPath:         " + EditorApplication.applicationPath);
    //    print("absoluteURL:             " + Application.absoluteURL);
    //    print("dataPath:                " + Application.dataPath);
    //    print("persistentDataPath:      " + Application.persistentDataPath);
    //    print("streamingAssetsPath:     " + Application.streamingAssetsPath);
    //    print("temporaryCachePath:      " + Application.temporaryCachePath);
    //    print("webSecurityHostUrl:      " + Application.webSecurityHostUrl);
    //    string assetBundlesPath = Application.dataPath + "/AssetBundles";
    //    if (!Directory.Exists(assetBundlesPath))
    //    {
    //        Directory.CreateDirectory(assetBundlesPath);
    //    }
    //    BuildPipeline.BuildAssetBundles(assetBundlesPath, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.iOS);
    //}
}
