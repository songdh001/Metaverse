using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : Stack.BaseUI
{

    Button startBtn;
    Button exitBtn;

    

    protected override Stack.UIState GetUIStates()
    {
        return Stack.UIState.Home;
    }

    public override void Init(Stack.UIManager uiManager)
    {
        base.Init(uiManager);

        startBtn = transform.Find("StartButton").GetComponent<Button>();
        exitBtn = transform.Find("ExitButton").GetComponent <Button>();

        startBtn.onClick.AddListener(OnClickStartButton);
        exitBtn.onClick.AddListener(OnClickExitButton);

    }

    void OnClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void OnClickExitButton()
    {
        uiManager.OnClickExit();
    }
}
