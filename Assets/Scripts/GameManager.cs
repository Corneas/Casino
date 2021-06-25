using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 minposition { get; private set; }
    public Vector2 maxposition { get; private set; }


    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int highscore = 0;
    [SerializeField]
    private int life = 3;
    [SerializeField]
    private Text scoretext = null;
    [SerializeField]
    private Text highscoretext = null;
    [SerializeField]
    private Text lifetext = null;

    void Start()
    {
        minposition = new Vector2(-5f, -5f);
        maxposition = new Vector2(5f, 5f);
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }

    


    void Update()
    {
        
    }

    public void Add(int addscore)
    {
        score += addscore;
        if(highscore < score)
        {
            highscore = score;
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
        }


        UpdateUI();
    }

    public void Dead()
    {
        life--;
        if(life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoretext.text = string.Format("{0}", score);
        highscoretext.text = string.Format("{0}", highscore);
        lifetext.text = string.Format("{0}", life);
    }





}
