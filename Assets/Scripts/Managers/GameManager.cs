using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [Header("STATS")]
    [SerializeField] int maxHeath = 20;
    public int coins = 100;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI healthLabel;
    [SerializeField] TextMeshProUGUI coinLabel;

    private int currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
        currentHeath = maxHeath;
        UpdateHealthLabel();
        UpdateCoinLabel();
    }

    public void UpdateHealth(int amount)
    {
        currentHeath += amount;
        UpdateHealthLabel();
    }

    private void UpdateHealthLabel()
    {
        healthLabel.text = "Health: " + currentHeath + "/" + maxHeath;
    }

    public void UpdateCoin(int amount)
    {
        coins += amount;
        UpdateCoinLabel();
    }

    private void UpdateCoinLabel()
    {
        coinLabel.text = "Coins: " + coins;
    }
}
