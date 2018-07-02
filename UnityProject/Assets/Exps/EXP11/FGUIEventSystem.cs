using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGUIEventSystem : MonoBehaviour {
    private string eventID = "10001";
	// Use this for initialization
	void Start () {
        EventListener test10001 = new EventListener(Stage.inst, eventID);

        GRoot.inst.SetContentScaleFactor(1136, 640);
        Stage.inst.onClick.Add(OnClick);
        Stage.inst.onClick.Add(OnClick1);
        //         Stage.inst.AddEventListener(eventID, (EventContext context) => 
        //         {
        //             Debug.LogError("收到了消息：" + eventID);
        //         });

        test10001.Add((EventContext context) =>
                 {
                     Debug.LogError("收到了消息：" + eventID+ "context.data="+ context.data);
                 });

        //         Stage.inst.onClick.Add(OnClick);
        //         Stage.inst.onClick.Set(OnClick1);
        //Stage.inst.AddEventListener("onClick", OnClick);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnClick(EventContext context)
    {
        Stage.inst.DispatchEvent(eventID,"123");
        //context.StopPropagation();
        Debug.LogError("点击了Stage");
    }
    void OnClick1(EventContext context)
    {
        Debug.LogError("点击了StageOnClick1"+ context.sender);
    }
}
