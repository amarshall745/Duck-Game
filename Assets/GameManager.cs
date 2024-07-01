using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject upgradeMenu;
    public bool pause;
    private bool menuOn, LockCursor;
    public GameObject gun2;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lockCursor();

        PlayerPrefs.SetFloat("fireRate", 1);
        PlayerPrefs.SetFloat("fireRange", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void upgradeMenuOn()
    {
        if (menuOn)
        {
            upgradeMenu.SetActive(false);
            lockCursor();
            menuOn = false;
            pause = false;
        }
        else
        {
            upgradeMenu.SetActive(true);
            lockCursor();
            menuOn = true;
            pause = true;
        }
    }

    public void lockCursor()
    {
        if (LockCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            LockCursor = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            LockCursor = true;
        }
    }

    public void setSingleShot()
    {
        gun2.SetActive(false);
    }

    public void setDoubleShot()
    {
        gun2.SetActive(true);
    }
}
