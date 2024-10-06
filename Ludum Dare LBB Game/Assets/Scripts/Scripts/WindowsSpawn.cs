
using Unity.Burst.CompilerServices;
using UnityEngine;

public class WindowsSpawn : MonoBehaviour
{
    public GameObject QuestionMarks;
    public GameObject WindowRope;
    public GameObject WindowLabirint;
    public GameObject WindowLabirint2;
    public GameObject WindowLabirint3;
    public LayerMask Ivent;

    public void SpawnWindow()
    {
        
        int RandomNumb = Random.Range(0, 6);
        GameObject Window;
        switch(RandomNumb)
        {
            
            case 0:
                Window = WindowRope;
                break;
            case 1:
                Window = WindowRope;
                break;
            case 2:
                Window = WindowRope;
                break;
            case 3:
                Window = WindowLabirint;
                break;
            case 4:
                Window = WindowLabirint2;
                break;
            case 5:
                Window = WindowLabirint3;
                break;
            default:
                Window = new GameObject();
                break;
        }
        Instantiate(Window, new Vector2(0, -2.25f), Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("AAAAAAAAAAA");
            RaycastFromMouse(); 
        }
    }

    void RaycastFromMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, Ivent);
        if(hit.collider != null)
        {
            if (hit.collider.CompareTag("Mark"))
            {
                SpawnWindow();
                SoundManager.Instance.PlayQuetionMarkSound();
                Destroy(hit.collider.gameObject);
            }
        }
    }  
}
