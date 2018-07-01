using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp9ExtensionCom : MonoBehaviour {

	// Use this for initialization
	void Start () {
         FairyGUI.UIObjectFactory.SetPackageItemExtension("ui://MainPack/ExtTestCom"
            , typeof(ExtensionComTest));
        Util.LoadAssets(new List<string>()
        {
            "MainPack.bytes",
            "MainPack@atlas_mvw21n.png",
            "MainPack@sprites.bytes",
            "MainPack@atlas0.png"
        }, Create);
	}

    void Create()
    {
       

        Util.AddFGUIPack("MainPack");
        GObject go = Util.CreateComAddToRoot("MainPack", "ExtComExp9");
        //          ExtensionComTest test1 = UIPackage.CreateObjectFromURL("ui://MainPack/ExtTestCom", 
        //              typeof(ExtensionComTest)) as ExtensionComTest;
        ExtensionComTest test1 = UIPackage.CreateObjectFromURL("ui://MainPack/ExtTestCom") as ExtensionComTest;
                GComponent com = go.asCom;
        com.AddChild(test1);
        test1.xy = new Vector2(0,0);
        //         com.GetChild("n1").asCom.GetChild("n1").visible = true;
        //         com.GetChild("n1").asCom.GetChild("n2").visible = false;
        ExtensionComTest test = com.GetChild("n1") as ExtensionComTest;

        test1.Init(1);
        test.Init(2);
    }

}
