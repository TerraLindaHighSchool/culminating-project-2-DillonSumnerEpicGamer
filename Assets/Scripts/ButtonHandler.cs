using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject Backround;
    public GameObject[] screens;
    public GameObject GameHandler;

    // Start is called before the first frame update
    void Start()
    {
        screens[0].SetActive(true);
        Backround.SetActive(true);
    }

    public void SetDifficulty(int diff)
    {
        GameHandler.GetComponent<SpawnHandler>().Difficulty = diff;
    }

    public void ChangeScreen(int ty)
    {
        screens[ty].SetActive(true);
    }

    public void HideScreen(int ty)
    {
        screens[ty].SetActive(false);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
