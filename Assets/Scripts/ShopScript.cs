using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Button fireRateButton;
    public Button movementSpeedButton;
    public Button damageBoostButton;

    int coins;

    // Start is called before the first frame update
    void Start()
    {
        fireRateButton.onClick.AddListener(BuyFireRate);
        movementSpeedButton.onClick.AddListener(BuyMovementSpeed);
        damageBoostButton.onClick.AddListener(BuyDamageBoost);
    }
    // Update is called once per frame
    void Update()
    {
        coins = PlayerScript.instance.coins;
    }
    void BuyFireRate()
    {
        if (coins >= 50)
        {
            PlayerScript.instance.arrowCooldown /= 5;
            PlayerScript.instance.coins -= 50;
        }
    }
    void BuyMovementSpeed()
    {
        if (coins >= 50)
        {
            PlayerScript.instance.speed += 5.0f;
            PlayerScript.instance.coins -= 50;
        }
    }
    void BuyDamageBoost()
    {
        if (coins >= 50)
        {
            PlayerScript.instance.arrowDamage += 1;
            PlayerScript.instance.coins -= 50;
        }        
    }
}
