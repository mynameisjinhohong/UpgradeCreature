using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Step
{
    public float UpgradePercentage;
    public Sprite[] IdleImage;
    public int NeedMoney;
    public int SellMoney;
    public float animationTime;
    //public int ImageX;
    //public int ImageY;
}

public class ChangeCharacter_HJH : MonoBehaviour
{
    public Text UpgradePercentageText;
    public Text NeedMoneyText;
    public Text SellMoneyText;
    public Image image;
    public List<Step> Steps;
    int nowStep = 0;
    bool changeImage = true;
    public float currentTime = 0;

    void Start()
    {
   
    }

    int idx = 0;
    // Update is called once per frame
    void Update()
    {
        image.sprite = Steps[nowStep].IdleImage[idx];
        UpgradePercentageText.text = "강화확률 : " + Steps[nowStep].UpgradePercentage + "%";
        NeedMoneyText.text = "필요 유전자 : " + Steps[nowStep].NeedMoney;
        SellMoneyText.text = "판매 가격 : " + Steps[nowStep].SellMoney;
        currentTime += Time.deltaTime;
        if(currentTime < (idx+2) * Steps[nowStep].animationTime && currentTime > (idx+1) * Steps[nowStep].animationTime)
        {
            image.SetNativeSize();
            idx++;
            if(idx >= Steps[nowStep].IdleImage.Length)
            {
                idx = 0;
                currentTime = 0;
            }
        }
        if (changeImage == true)
        {
            changeImage = false;
            idx = 0;
        }
    }
    public void UpgradeButton()
    {
        if(GameManager.instance.money > Steps[nowStep].NeedMoney)
        {
            GameManager.instance.money = GameManager.instance.money - Steps[nowStep].NeedMoney;
            float check = Random.Range(0f, 100f);
            if (check < Steps[nowStep].UpgradePercentage)
            {
                nowStep++;
                changeImage = true;
            }
            else
            {
                nowStep = 0;
                changeImage = true;
            }
            currentTime = 0;
            idx = 0;
        }
    }

    public void SellButton()
    {
        GameManager.instance.money += Steps[nowStep].SellMoney;
        nowStep = 0;
        changeImage = true;
    }
}
