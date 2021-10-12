using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //Scoring
    public Text ScoreText;
    public float TotalScore;

    public int Score;

    //Timer
    public Text TimerText;
    public float TimeLeft;
    public float TimeRemaining;

    private float TimerValue;

    //ParticleSystem
    public ParticleSystem CoinParticle;

    // Start is called before the first frame update
    void Start()
    {
        CoinParticle.Stop();
        CoinParticle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Score (Coin)
        ScoreText.text = "Coin: " + Score;

        //Timer
        TimeLeft -= Time.deltaTime;
        TimeRemaining = Mathf.FloorToInt(TimeLeft % 60);
        TimerText.text = "Timer: " + TimeRemaining.ToString();

        if (Score == TotalScore)
        {
            if (TimeLeft <= TimerValue)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        else if(TimeLeft <= 1)
        {
            SceneManager.LoadScene("GameLose");
        }

        if (Score >= 60)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //When collides with Coin
        if (other.gameObject.tag == "Coin")
        {
            CoinParticle.Play();
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
