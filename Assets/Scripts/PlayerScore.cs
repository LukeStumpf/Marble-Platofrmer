using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    private GameObject[] coins;
    private int coinCount;

    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coins");
        coinCount = coins.Length;

        Debug.Log("The coin count = " + coinCount.ToString());
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Coins")
        {
            coinCount --;
            GameObject.Destroy(collider.gameObject);
            Debug.Log("The coin count = " + coinCount.ToString());

            if (coinCount <= 0)
            {
                Debug.Log("You Win!");
                SceneManager.LoadScene(2);
            }
        }
    }
}
