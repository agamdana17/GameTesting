using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text TextScore, TextTotalScore;

    public void Start()
    {
        if (Data.DataScore >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", Data.DataScore);
        }

        TextScore.text = Data.DataScore.ToString();
        TextTotalScore.text = PlayerPrefs.GetInt("score").ToString();

    }

}
