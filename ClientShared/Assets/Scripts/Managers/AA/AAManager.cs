using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AAManager : MonoBehaviour
{
    public string assetName = "Assets/Bundles/Prefabs/Bullet.prefab";

    void Start()
    {
        //InstantiateBetaObj();
    }

    private async void InstantiateBetaObj()
    {
        //ʹ��LoadAssetAsync����
        //GameObject betaPrefabObj = await Addressables.LoadAssetAsync<GameObject>(assetName).Task;
        //GameObject betaObj1 = Instantiate(betaPrefabObj);
        //betaObj1.transform.position = new Vector3(2, 0, 0);

        //ʹ��InstantiateAsync����
        GameObject betaObj2 = await Addressables.InstantiateAsync(assetName).Task;
        betaObj2.transform.position = new Vector3(4, 0, 0);
        betaObj2.name = "AA_Object";
    }
}