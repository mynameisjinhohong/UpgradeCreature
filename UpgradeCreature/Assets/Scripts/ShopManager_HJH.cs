using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager_HJH : MonoBehaviour
{
    public Canvas gameCanavs;
    public Canvas shopCanvas;

    public void ShopOnButton()
    {
        shopCanvas.gameObject.SetActive(true);
        gameCanavs.gameObject.SetActive(false);
    }

    public void GameOnButton()
    {
        gameCanavs.gameObject.SetActive(true);
        shopCanvas.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
