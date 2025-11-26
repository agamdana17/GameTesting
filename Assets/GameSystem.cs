using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Data
{
    public static int DataLevel, DataScore, DataWaktu, DataDarah;
}

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;

    int MaxLevel = 5;

    [Header("Data Games")]
    public bool GameActive; 
    public bool GameOver;
    public bool RandomSys;
    public int Target, DataNow;
    
    [Header("Komponen UI")]
    public Text Text_Level;
    public Text Text_Waktu, Text_Score;
    public RectTransform Ui_Nyawa;

    [Header("Object GUI")]
    public GameObject Gui_Pause;
    public GameObject Gui_Trantition;



    [System.Serializable]
    public class DataGame
    {
        public string Name;
        public Sprite Photo;
    }

    [Header("Setting Standar")]
    public DataGame[] DataGames;

    [Space]
    [Space]
    [Space]

    public Obj_DropPlace[] Drop_Place;
    public Obj_Drag[] Drag_Obj;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameActive = false;
        GameOver = false;
        ResetData();
        RandomQuiz();
        Target = Drop_Place.Length;


        DataNow = 0;
        GameActive = true;

    }

    [HideInInspector]public List<int> _RandomQuiz = new List<int>();
    [HideInInspector]public List<int> _RandomPos = new List<int>();


    int random;
    int random2;
    public void RandomQuiz()
    {
        _RandomQuiz.Clear();
        _RandomPos.Clear();

        _RandomQuiz = new List<int>(new int[Drag_Obj.Length]);

        for (int i = 0; i < _RandomQuiz.Count; i++)
        {
            random = Random.Range(1, DataGames.Length);
            while (_RandomQuiz.Contains(random))
                random = Random.Range(1, DataGames.Length);

            _RandomQuiz[i] = random;

            Drag_Obj[i].ID = random - 1;
            Drag_Obj[i].Text.text = DataGames[random - 1].Name;
        }

        _RandomPos = new List<int>(new int[Drop_Place.Length]);

        for (int i = 0; i < _RandomPos.Count; i++)
        {
            random2 = Random.Range(1, _RandomQuiz.Count + 1);
            while (_RandomPos.Contains(random2))
                random2 = Random.Range(1, _RandomQuiz.Count + 1);

            _RandomPos[i] = random2 ;

            Drop_Place[i].Drop.ID = _RandomQuiz[random2 - 1] - 1;
            Drop_Place[i].Gambar.sprite = DataGames[Drop_Place[i].Drop.ID].Photo;
        }
    }

    private void ResetData()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game0")
        {

            Data.DataWaktu = 60 * 3;
            Data.DataScore = 0;
            Data.DataDarah = 5;
            Data.DataLevel = 0;
        }
    }



    float s;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            RandomQuiz();

        if (GameActive && !GameOver)
        {
            if(Data.DataWaktu > 0){
                s += Time.deltaTime; 
                if(s >= 1)
                {
                    Data.DataWaktu--;
                    s = 0;
                }
            }
            if(Data.DataWaktu <= 0)
            {
                GameActive = false;
                GameOver = true;

                //game kalah
                Gui_Trantition.GetComponent<UI_Control>().Btn_Move("GameFinish");
            }

            if (Data.DataDarah <= 0) {
                GameActive = false;
                GameOver = true;

                //game kalah
                Gui_Trantition.GetComponent<UI_Control>().Btn_Move("GameFinish");

            }

            if(DataNow >= Target)
            {
                GameOver  = true ;
                GameActive = false;

                // Kita Menang

                if(Data.DataLevel < (MaxLevel - 1)){
                    Data.DataLevel++;
                    //Pindah Level

                    UnityEngine.SceneManagement.SceneManager.LoadScene("Game" + Data.DataLevel);
                    //Gui_Trantition.GetComponent<UI_Control>().Btn_Move("Game" + Data.DataLevel);
                }
                else
                {
                    //Game Selesai
                    Gui_Trantition.GetComponent<UI_Control>().Btn_Move("GameFinish");
                }

            }


        }

        SetInfoUI();

    }

    public void SetInfoUI()
    {
        Text_Level.text = (Data.DataLevel + 1).ToString();

        int Menit = Mathf.FloorToInt(Data.DataWaktu / 60); 
        int Detik = Mathf.FloorToInt(Data.DataWaktu % 60);
        Text_Waktu.text = Menit.ToString("00") + " : " + Detik.ToString("");

        Text_Score.text = Data.DataScore.ToString();

        Ui_Nyawa.sizeDelta = new Vector2(49f * Data.DataDarah, 49f);
    }

    public void Btn_Pause(bool pause)
    {

        if (pause)
        {
            GameActive = false;
            Gui_Pause.SetActive(true);

        }
        else
        {
            GameActive = true;
            Gui_Pause.SetActive(false);
        }
    }


}
