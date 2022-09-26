using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{

    public GameObject GameOverText;
    public static GameObject GameOverStatic;

    [SerializeField]
    private TMPro.TextMeshProUGUI m_PuntsFinal;
    public ControladorCirculo m_vikingo;





    // Start is called before the first frame update
    void Start()
    {
        Over.GameOverStatic = GameOverText;
        Over.GameOverStatic.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
         m_PuntsFinal.text = "SCORE X "+m_vikingo.Punts.ToString();
    }

    public static void show(){
        Over.GameOverStatic.gameObject.SetActive(true);
    }
    public static void hide(){
        Over.GameOverStatic.gameObject.SetActive(false);
    }
}
