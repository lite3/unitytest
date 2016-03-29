using UnityEngine;
using System.Collections;
using System.IO;

public class AssetBoundleTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

        LoadPrefab();
        
	}

    private void LoadPrefab()
    {
        // prefabs依赖于cubeatlas,需要先加载cubeatlas
        LoadAssetBundle("/materials/cubeatlas").LoadAllAssets();
        Object[] objs = LoadAssetBundle("/prefabs/cubeprefab").LoadAllAssets();
        foreach (Object obj in objs)
        {
            print(obj);
            GameObject.Instantiate(obj);
        }
        objs = LoadAssetBundle("/prefabs/sphereprefab").LoadAllAssets();
        foreach (Object obj in objs)
        {
            print(obj);
            GameObject.Instantiate(obj);
        }
        Resources.UnloadUnusedAssets();
    }

    private AssetBundle LoadAssetBundle(string path)
    {
        byte[] buffer = File.ReadAllBytes(PathUtil.streamingAssetsPath + path);
        AssetBundle ab = AssetBundle.CreateFromMemoryImmediate(buffer);
        return ab;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
