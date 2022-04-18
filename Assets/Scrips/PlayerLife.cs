using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    bool dead = false;
    [SerializeField] AudioSource dieSound;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy body"))
        {
            GetComponent<MeshRenderer>().enabled = false; //prevent collision with enemy head after die
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }

        if (collision.gameObject.CompareTag("Enemy head"))
        {
            Destroy(collision.transform.parent.gameObject);
            GetComponent<PlayerMovement>().Jump();
        }
    }

    private void Die()
    {

        dead = true;
        Invoke(nameof(ReloadGame), 1.3f);
        dieSound.Play();
        PlayerPrefs.SetInt("coins", 0);
        Debug.Log("Coins = 0 because of death");

    }

    private void ReloadGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
