using UnityEngine;
using System.Collections;
using System.IO;

public class FileUtil {

	public static bool GetData(string filepath, out byte[] bytes)
    {
        FileStream fs = new FileStream(filepath, FileMode.Open);
        bytes = new byte[fs.Length];
        int size = fs.Read(bytes, 0, (int)fs.Length);
        fs.Close();
        return true;
    }
}
