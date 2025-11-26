using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class Obj_Drag : MonoBehaviour
{
    [HideInInspector] public Vector2 SavePosisi;
    [HideInInspector] public bool IsOnObj;
        
    Transform SaveObj;

    public int ID;
    
    public Text Text;

    [Space]

    public UnityEvent OnDragCor;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SavePosisi = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        

    }

    private void OnMouseUp()
    {
        /**/  
        if (IsOnObj)
        {
            int ID_DropPlace = SaveObj.GetComponent<Drop_Place>().ID;
             
                if(ID == ID_DropPlace)
                {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(0.75f, 0.75f);

                SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                SaveObj.GetComponent<BoxCollider2D>().enabled = false;

                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                OnDragCor.Invoke();

                //jika benar
                GameSystem.instance.DataNow++;
                Data.DataScore += 10;


                }

                else
                {
                    transform.position = SavePosisi;
                
                // jika salah
                Data.DataDarah --;
                }
        }
        else
        {
            transform.position = SavePosisi;

            //Jika tempatnya salah

        }


    }
        

    private void OnMouseDrag()
    {
        if(!GameSystem.instance.GameOver)
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Pos;
        }

    }


    private void OnTriggerStay2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsOnObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Drop"))
        {
            IsOnObj = false;
        }
    }
}
