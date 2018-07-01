using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    private static Dictionary<string, object> mCacheRes = new Dictionary<string, object>();
    public static void LoadAssets(List<string> loadNames,Action callback)
    {
        foreach (string name in loadNames)
        {
            string fileName = "Assets/AB/" + name;
            mCacheRes[name] = UnityEditor.AssetDatabase.LoadMainAssetAtPath(fileName);
        }
        if (callback != null)
            callback();
    }

    public static void AddFGUIPack(string packName)
    {
        FairyGUI.UIPackage.AddPackage(packName, GetRes);
    }

    static object GetRes(string name, string extension, System.Type type)
    {
        object res = null;
        if (mCacheRes.TryGetValue(name + extension, out res))
        {
            return res;
        }
        return null;
    }

    public static GObject CreateComAddToRoot(string packName,string resName)
    {
        GObject go = UIPackage.CreateObject(packName, resName);
        if (go != null)
        {
            GRoot.inst.AddChild(go);
            go.size = GRoot.inst.size;
            go.Center(true);
        }
        else
        {
            Debug.LogError("创建失败:" + "packName=" + packName + "/resName=" + resName);
        }
        return go;
    }
}
