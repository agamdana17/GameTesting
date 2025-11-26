using UnityEngine;
using UnityEngine.SceneManagement;




public class UI_Control : MonoBehaviour
{
    public bool IsTrantition, IsNoTranstition;

    string SaveNameScene;

    private void Awake()
    {
        if (IsTrantition && IsNoTranstition)
        {
            gameObject.SetActive(false);
        }
    }
    public void Btn_Sound(int id)
    {
        AllSound.Instance.Call_Sfx(0);
    }

    public void Btn_Move(string name)
    {
        this.gameObject.SetActive(true);
        SaveNameScene = name;
        GetComponent<Animator>().Play("End");
    }

    public void Btn_Restart()
    {
        SaveNameScene = SceneManager.GetActiveScene().name;
        GetComponent<Animator>().Play("End");
    }

    public void Move()
    {
        SceneManager.LoadScene(SaveNameScene);


    }

    public void Btn_QuitGame()
    {
        Application.Quit();
    }


}