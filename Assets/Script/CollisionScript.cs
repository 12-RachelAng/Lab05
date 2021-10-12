using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //Scoring
    public Text ScoreText;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Coin: " + Score;
    }

    public void OnTriggerEnter(Collider other)
    {
        //When collides with Coin
        if (other.gameObject.tag == "Coin")
        {
            Score += 10;
            ScoreText.text = "Coin: " + Score;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
