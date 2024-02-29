using HotFix;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Present present; //通过请求返回

    [SerializeField]
    private Transform canvasRoot;
    [SerializeField]
    private UI_CheckUpdate ui_check;

    void Awake()
    {
        GameObject poolManager = new GameObject("PoolManager");
        poolManager.transform.SetParent(this.transform);
        poolManager.AddComponent<PoolManager>();

        GameObject aaManager = new GameObject("AAManager");
        aaManager.transform.SetParent(this.transform);
        aaManager.AddComponent<AAManager>();

        GameObject uiManager = new GameObject("UIManager");
        uiManager.transform.SetParent(this.transform);
        uiManager.AddComponent<HotFix.UIManager>();

        GameObject audioManager = new GameObject("AudioManager");
        audioManager.transform.SetParent(this.transform);
        //audioManager.AddComponent<AudioManager>();

        // 初始UI
        canvasRoot = GameObject.Find("Canvas").transform;
        string ui_name = "UI_CheckUpdate";
        GameObject asset = Resources.Load<GameObject>(ui_name);
        GameObject obj = Instantiate(asset, canvasRoot);
        obj.name = ui_name;
        if (obj.GetComponent<UI_CheckUpdate>() == false)
            obj.AddComponent<UI_CheckUpdate>();
        ui_check = obj.GetComponent<UI_CheckUpdate>();
    }

    void Start()
    {
        //TODO:
        // 此处应校验资源版本
        // 校验完成后，Hotfix初始化
        // 出UI逻辑交给Hotfix
        //UIManager.Get().Push<UI_Login>();

        //Resources.Load("UI_CheckUpdate");
    }
}