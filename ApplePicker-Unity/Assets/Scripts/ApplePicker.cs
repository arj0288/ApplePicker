/*
 * Created by: ALex Jenkins
 * Date Created: 2/09/22
 * 
 * Last Edited: 2/10/22
 * Last Edited By: N/A
 * 
 * Description: Controls game overall
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0;i<numBaskets;i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            Application.LoadLevel("TestScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
