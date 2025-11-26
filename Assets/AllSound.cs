using UnityEngine;

public class AllSound : MonoBehaviour
{
    public static AllSound Instance;

    public AudioClip[] Clip;

    public AudioSource source_sfx;

    public AudioSource source_bgm;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    public void Call_Sfx(int id)
    {
        source_sfx.PlayOneShot(Clip[id]);
    }


}
