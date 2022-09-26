using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static ControladorCirculo;


public class ControladorCirculo : MonoBehaviour
{
	public float m_speed = 2f;
    public int m_jump = 7;
    public bool m_s = true;
    public int dbjump = 2;
    public int cont = 0;
    public bool m_dead = false;

    

    private Rigidbody2D m_rbody;
    public SpriteRenderer m_r;
    public GameObject camara;
    public Transform m_trs;
    

    //PUNTUACIÓN
    private float m_Punts;  // camp privat que utilitzem
    public float Punts   // Accessor (getter) del camp anterior
    {
        get => m_Punts;
    }

    public delegate void PlayerDead();
    public event PlayerDead OnPlayerDead;



    void Awake()
    {
        m_rbody = GetComponent<Rigidbody2D>();

    }
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (m_dead)
            return;

        if (Input.GetKey(KeyCode.D)){
            m_rbody.velocity = new Vector3(m_speed,m_rbody.velocity.y,0);
            m_r.flipX = true;
        }
        if(Input.GetKey(KeyCode.A)){
            m_rbody.velocity = new Vector3(-m_speed,m_rbody.velocity.y,0);
            m_r.flipX = false;

        }
        if(dbjump > 0){
            if(Input.GetKeyDown(KeyCode.W)){
                m_rbody.velocity = new Vector3(m_rbody.velocity.x,m_jump,0);
                dbjump--;
               
            }
		}

        m_Punts = cont;
    }

    void OnCollisionEnter2D(Collision2D c)
    {

         if (c.gameObject.tag == "Suelo"){
            print("Collision");
            dbjump = 2;
         }
           
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("TRIGGER: La pilota ha entrat a una col·lisió amb " + col.gameObject);
		Destroy(col.gameObject);

        if (col.gameObject.tag == "tesoro") {
            cont++;        
        }
        if (col.gameObject.tag == "obstaculo")
        {
            m_dead = true;
            OnPlayerDead.Invoke();
            //Destroy(this.gameObject);
        }

    }

    public void ReGame()
    {
        m_dead = false;
        cont = 0;
        m_trs.position = new Vector3(0,0,0);

    }
}