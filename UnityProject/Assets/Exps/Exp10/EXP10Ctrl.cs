using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EXP10Ctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Util.LoadAssets(new List<string>() { "MainPack.bytes",
            "MainPack@atlas_mvw21n.png",
            "MainPack@sprites.bytes",
            "MainPack@atlas0.png" }, Create);

    }
	
	// Update is called once per frame
	void Create () {
        Util.AddFGUIPack("MainPack");
        GObject go = Util.CreateComAddToRoot("MainPack", "Exp10Ctrl");
        Controller c1 = go.asCom.GetController("c1");
        Controller c2 = go.asCom.GetController("c2");
        c1.selectedIndex = 0;
        //c2.selectedIndex = 0;
        c2.selectedIndex = 1;
        //c1.selectedIndex = 1;
        //c2.selectedIndex = 0;
        //c2.selectedIndex = 1;
    }
}
