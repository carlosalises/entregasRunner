using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_GUI : MonoBehaviour
{
    [SerializeField]
    private ControladorCirculo m_Personatge;
    private TMPro.TextMeshProUGUI m_Text;

    public GameObject PuntsText;
    public static GameObject PuntsTextStatic;
    

    private void Awake()
    {
        m_Text = GetComponent<TMPro.TextMeshProUGUI>();
        C_GUI.PuntsTextStatic = PuntsText;
    }


    private void Update()
    {
        m_Text.text = "PUNTS X "+m_Personatge.Punts.ToString();
    }

    public static void hide(){
        C_GUI.PuntsTextStatic.gameObject.SetActive(false);
    }
    public static void show()
    {
        C_GUI.PuntsTextStatic.gameObject.SetActive(true);
    }


}
