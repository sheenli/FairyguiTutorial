using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FairyGUI.Utils;

/************************************************************************/
/*    创建这个组件前注册
/************************************************************************/

public class ExtensionComTest : GComponent
{
    private GImage mJionRoom;
    private GImage mCreateRoom;
    public override void ConstructFromXML(XML xml)
    {
        base.ConstructFromXML(xml);
        mJionRoom = this.GetChild("n1").asImage;
        mCreateRoom = this.GetChild("n2").asImage;
    }

    public void Init(int type)
    {
        if (type == 1)
        {
            mJionRoom.visible = true;
            mCreateRoom.visible = false;
        }
        else
        {
            mJionRoom.visible = false;
            mCreateRoom.visible = true;
        }
    }
}
