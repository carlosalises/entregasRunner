using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }

    private int m_Score = 0;
    public int Score
    {
        get { return m_Score; }
        set { m_Score = value; }
    }

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
        InitValues();
    }

    //Es crida al carregar una escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.name == "GameScene")
            InitValues();
    }

    private void InitValues()
    {
        m_Score = 0;
        //resetejar la dificultat, etc
    }

    void Update()
    {
        //nicament a mode d'exemple
        if (Input.GetKeyDown(KeyCode.L))
            SceneManager.LoadScene("GameOver");

    }

}
