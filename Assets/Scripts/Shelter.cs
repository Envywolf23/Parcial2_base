using UnityEngine;
using UnityEngine.SceneManagement;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;

    private int contadorResistencia;
    private float regenTime;



    public void Start()
    {
        contadorResistencia = maxResistance;
        regenTime = 5f;
    }

    public int MaxResistance
    {
        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }

    public void Damage(int damage)
    {
        contadorResistencia -= damage;

        if (regenTime == 5f)
        {
            Regeneration();
        }
        

        if (regenTime != 5f)
        {
            regenTime = 5f;
            Regeneration();
        }

        
    }

    public void Regeneration()
    {
        if(contadorResistencia != maxResistance)
        {
            regenTime -= Time.deltaTime;

            if (regenTime <= 0f)
            {
                contadorResistencia += 1;
                regenTime = 5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>())
        {
            if(contadorResistencia != 0)
            {
                Damage(1);
            }
            else
            {
                SceneManager.LoadScene("Game Over");
            }
        }
    }

}
