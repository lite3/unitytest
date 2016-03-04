using UnityEngine;
using System.Collections;

public class PathUtil {

    private static string _streamingAssetsPath = null;
	public static string streamingAssetsPath
    {
        get
        {
            if (string.IsNullOrEmpty(_streamingAssetsPath))
            {
                _streamingAssetsPath = Application.streamingAssetsPath;
                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsEditor:
                    case RuntimePlatform.WindowsPlayer:
                        _streamingAssetsPath = windowsStreamingAssetsPath;
                        break;
                    case RuntimePlatform.OSXEditor:
                    case RuntimePlatform.OSXPlayer:
                        _streamingAssetsPath = osxStreamingAssetsPath;
                        break;
                    case RuntimePlatform.Android:
                        _streamingAssetsPath = androidStreamingAssetsPath;
                        break;
                    case RuntimePlatform.IPhonePlayer:
                        _streamingAssetsPath = iosStreamingAssetsPath;
                        break;
                }
            }
            return _streamingAssetsPath;
        }
    }

    public static string windowsStreamingAssetsPath
    {
        get { return Application.streamingAssetsPath + "/Windows"; }
    }
    public static string osxStreamingAssetsPath
    {
        get { return Application.streamingAssetsPath + "/OSX"; }
    }
    public static string androidStreamingAssetsPath
    {
        get { return Application.streamingAssetsPath + "/Android"; }
    }
    public static string iosStreamingAssetsPath
    {
        get { return Application.streamingAssetsPath + "/IOS"; }
    }
}
