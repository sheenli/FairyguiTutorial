using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

public class ShowImageToUnityExp : MonoBehaviour
{
    private Dictionary<string, object> mResCache = new Dictionary<string, object>();
    private GComponent mShowImagetoUintyCom = null;
    void Awake()
    {
        UIConfig.defaultFont = "test";
        FairyGUI.FontManager.RegisterFont(FontManager.GetFont("Microsoft Yahei"), "迷你简准圆");
        GRoot.inst.SetContentScaleFactor(1136, 640);

        LoadRes(() =>
        {
            UIPackage.AddPackage("MainPack", GetRes);
            CreateCom();
        });
    }
    void LoadRes(Action callback)
    {
        List<string> loadNames = new List<string>()
        {
            "MainPack.bytes",
            "MainPack@atlas_mvw21n.png",
            "MainPack@sprites.bytes",
            "MainPack@atlas0.png"
        };
        foreach (string name in loadNames)
        {
            string fileName = "Assets/AB/" + name;
            mResCache[name] = UnityEditor.AssetDatabase.LoadMainAssetAtPath(fileName);
        }
        if(callback != null)
        callback();
    }

    object GetRes(string name, string extension, System.Type type)
    {
        object res = null;
        if (mResCache.TryGetValue(name + extension,out res))
        {
            return res;
        }
        return null;
    }
    
    void CreateCom()
    {
        GObject go = UIPackage.CreateObject("MainPack", "showImagetoUinty");
        if (go != null)
        {
            mShowImagetoUintyCom = go.asCom;
            GRoot.inst.AddChild(mShowImagetoUintyCom);
            mShowImagetoUintyCom.size = GRoot.inst.size;
            mShowImagetoUintyCom.Center(true);
            string data= mShowImagetoUintyCom.packageItem
                .componentData.GetAttribute("customData");
            Debug.LogError("customData="+data);
        }
        else
        {
            Debug.LogError("创建对象失败");
        }
        //this.TestTextFieldAndInut();
    }

#region 文本测试代码
    public void TestTextFieldAndInut()
    {
        GTextField mTextFieldTest = this.mShowImagetoUintyCom.GetChild("TextFieldTest")
            .asTextField;
        mTextFieldTest.text = "测试";

        GTextInput input = mTextFieldTest.asTextInput;
        if (input != null)
        {
            input.editable = false;
        }
    }
#endregion
}
