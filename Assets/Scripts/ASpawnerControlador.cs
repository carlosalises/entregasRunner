using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ASpawnerControlador : MonoBehaviour
{
    [SerializeField]
    private ControladorCirculo m_Player;
    private Over m_Over;

    [SerializeField]
    private GameObject m_ElementASpawnejar;
    [SerializeField]
    private Transform m_PuntSpawnA;
    [SerializeField]
    private Transform m_PuntSpawnB;

    private Vector3 InitPos;
    [SerializeField] Vector3 DestPos;
    private Vector3 FinalPos;


    [SerializeField]
    private GameObject[] m_ElementASpawnejarVaixell;
    [SerializeField]
    private Transform m_PuntSpawnVaixell;

    [SerializeField]
    private float m_SpRate = 8f;


    // Start is called before the first frame update
    void Start()
    {
        Inicialitzar();
        m_Player.OnPlayerDead += PlayerDead;
     

    }

    private void Inicialitzar()
    {
        StartCoroutine(DispararA(m_PuntSpawnA));
        StartCoroutine(DispararA(m_PuntSpawnB));
        StartCoroutine(DispararB());
        StartCoroutine(MasDificultat());
    }

    private void PlayerDead()
    {
        StopAllCoroutines();
        Over.show();
        C_GUI.hide();
    }

    

    IEnumerator DispararA(Transform puntSpawn)
    {
        while (true)
        {
            float SpawnRate = Random.Range(1f, 6f);
            yield return new WaitForSeconds(SpawnRate);

            GameObject spawned = Instantiate(m_ElementASpawnejar);
            spawned.transform.position = puntSpawn.position;
            spawned.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0);
        }
    }

    IEnumerator DispararB()
    {
        while(true)
        {
            int r = Random.Range(0, m_ElementASpawnejarVaixell.Length);

            if (r == 0) {
                GameObject spawned = Instantiate(m_ElementASpawnejarVaixell[1]);
                spawned.transform.position = m_PuntSpawnVaixell.position;
                spawned.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -3, 0);
            }
            else {
                GameObject spawned = Instantiate(m_ElementASpawnejarVaixell[0]);
                spawned.transform.position = m_PuntSpawnVaixell.position;
                spawned.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5, 0);
            }
   
           
            yield return new WaitForSeconds(m_SpRate);
        }
        
    }

    IEnumerator MasDificultat()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            m_SpRate -= 0.5f;

            if (m_SpRate <= 1.5f)
                m_SpRate = 1.5f;
        }
    }

    public void Renaudar()
    {
 
            Inicialitzar();
            m_SpRate = 8;
            m_Player.ReGame();
            C_GUI.show();
            Over.hide();


    }

}
