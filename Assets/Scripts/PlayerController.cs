using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region //Variáveis para controlar a mudança das formas
    [SerializeField] private Animator anim;
    private bool souCavalo = false;
    #endregion

    #region // Mecâniccas da forma 2
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float velShot = 10f; 
    #endregion

    #region //atributos do player
    private Rigidbody2D myRb;
    [SerializeField] private float velPlayer;
    [SerializeField] private int life = 10;
    [SerializeField] private float stamina = 20f;
    #endregion
    #region // limites do player
    private float xMax = 8.24f;
    [SerializeField] private float yMin = -3.92f;
    [SerializeField] private float yMax = -1.08f;
    #endregion
    public float sec;
    [SerializeField] private GameObject atk;
    [SerializeField] private Transform pointAtk;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        var change = Input.GetKeyDown(KeyCode.P);
        var cavaleiro = Input.GetKeyDown(KeyCode.L);

        if( change )
        {
            if( souCavalo == false)
            {
              Forma2();
              stamina = 20f;
              Debug.Log("Virei cavalo em");
            }
            else
            {
                Forma1();
                stamina = 20f;
                Debug.Log("Não sou mais cavalo");
            }
        }
        if (stamina <=0 && souCavalo == false )
        {
            Forma2();
            stamina = 20f;
        }
        else if( stamina <= 0 && souCavalo)
        {
            Forma1();
            stamina = 20f;
        }

        HorseShot();
        BonesAttack();
        Move();
    }
    void Forma1()
    {
        souCavalo = false;
        anim.SetBool( "Ranged", false);
    }
    void Forma2()
    {
        souCavalo = true;
        anim.SetBool( "Ranged", true );
    }
    void Move()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        Vector2 myVelocity = new Vector2( h , v );

        myVelocity.Normalize();
        myRb.velocity = myVelocity * velPlayer;

        float meuX = Mathf.Clamp( transform.position.x, - xMax, xMax );
        float meuY = Mathf.Clamp( transform.position.y, yMin, yMax );


        transform.position = new Vector3(meuX, meuY, transform.position.z);

        if( Input.GetButton("Horizontal") || Input.GetButton("Vertical") )
        {
            stamina -=Time.deltaTime;
        }
    }

    void HorseShot()
    {
        if( souCavalo && Input.GetButtonDown("Fire1"))
        {
            //atireeei
            var fire = Instantiate( fireBall, firePoint.position, Quaternion.identity );
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2( velShot, 0f);
        }
    }
    public void BonesAttack()
    {
        if ( souCavalo == false && Input.GetButtonDown("Fire1") )
        {
            anim.SetTrigger( "Attack");
        }
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        if( life <= 0 )
        {
           Destroy(gameObject);
        }
    }
}
