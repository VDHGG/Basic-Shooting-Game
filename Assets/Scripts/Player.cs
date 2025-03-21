using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject Bullet;
    public Transform ShootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSound;
    public AudioClip playerDieSound;
    
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
          Input.GetAxisRaw("Horizontal")
          Cau lenh nay tuc la ta se dieu khien nhan vat Player theo chieu ngang (Horizontal)
          Cau lenh nay lay gia tri khi ta nhan phim tren bo dieu khien va o day la ban phim
          left = -1 ; khong nhan gi = 0; right = 1  
          sau do no se lien tuc luu gia tri vao bien XDir do ham void Update
         */
        float xDir = Input.GetAxisRaw("Horizontal");       
        if ((xDir < 0 && transform.position.x <= -7 || xDir >0 && transform.position.x >= 12))
            return; 

        // vector3.right la viet tat cua toa do (x,y,z) = (1,0,0)
        transform.position = transform.position + Vector3.right * moveSpeed * xDir * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(Bullet != null && ShootingPoint != null)
        {
            if (aus != null && shootingSound != null) 
            {
                aus.PlayOneShot(shootingSound); 
            }  
            Instantiate(Bullet, ShootingPoint.position, Quaternion.identity); 

        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.CompareTag("Enemy"))
        {
            m_gc.SetGameoverState(true);
            Destroy(col.gameObject);
            if(aus != null && playerDieSound != null)
            {
                aus.PlayOneShot(playerDieSound);                
            }
            Destroy(gameObject);          
  
            Debug.Log("YOU DIEEEEE!!!");            
        }     

    }


    


}
