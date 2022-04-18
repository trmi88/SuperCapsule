using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            NextLevel();
            
        }
    }

    private void NextLevel()
    {
        int coins = player.GetComponent<ItemCollector>().coins;
        PlayerPrefs.SetInt("coins", coins);
        Debug.Log("set coins to " + PlayerPrefs.GetInt("coins"));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
