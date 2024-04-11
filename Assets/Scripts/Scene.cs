using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
   
    public void ChangeWorld1()
    {
        SceneManager.LoadScene("World1");
    }
    public void ChangeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
