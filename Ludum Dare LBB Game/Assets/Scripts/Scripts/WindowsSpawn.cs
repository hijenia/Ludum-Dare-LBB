
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
        
        int RandomNumb = Random.Range(0, 4);
        GameObject Window;
        switch(RandomNumb)
        {
            case 0:
                Window = WindowRope;
                break;
            case 1:
                Window = WindowLabirint;
                break;
            case 2:
                Window = WindowLabirint2;
                break;
            case 3:
                Window = WindowLabirint3;
                break;
            default:
                Window = new GameObject();
                break;
        }
        Instantiate(Window, Vector2.zero, Quaternion.identity);
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
            }
        }
    }  
}
