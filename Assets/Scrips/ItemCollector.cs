using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    public int coins;
    [SerializeField] Text coinText;
    [SerializeField] AudioSource collectingSound;

    private void Start()
    {
        if (PlayerPrefs.HasKey("coins") && SceneManager.GetActiveScene().buildIndex > 0)
        {
            Debug.Log("get coins = " + PlayerPrefs.GetInt("coins"));

            coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            coins = 0;
        }
        SetCoin();
    }

    void SetCoin()
    {
        coinText.text = "Coins: " + coins;

    }

    public void AddCoin()
    {
        coins++;
        SetCoin();
        collectingSound.Play();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddCoin();
        }
    }
}
