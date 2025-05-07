using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public TextMeshProUGUI stackScoreText;
    public TextMeshProUGUI stackComboText;
    public TextMeshProUGUI TopDownBestWave;
    public TextMeshProUGUI BirdBestScore;

    // Start is called before the first frame update
    void Start()
    {
        stackScoreText.text = "Best Stack Score :" + PlayerPrefs.GetInt("Stack_Score", 0);
        stackComboText.text = "Best Stack Combo :" + PlayerPrefs.GetInt("Stack_Combo", 0);
        TopDownBestWave.text = "Best Wave :" + PlayerPrefs.GetInt("TopDownBestWave", 0);
        BirdBestScore.text = "Best Bird Score :" + PlayerPrefs.GetInt("BirdBestScore", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
