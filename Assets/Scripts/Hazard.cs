using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;
    public int clase;

    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;

    // Use this for initialization
    protected void Start()
    {
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }


    protected void Update()
    {
        if(clase == 2)
        {
            transform.Rotate(0f, 0f, 0.8f);
        }

        
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }

           
        }

        if(collision.gameObject.GetComponent<Shelter>() != null)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }

    protected void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}