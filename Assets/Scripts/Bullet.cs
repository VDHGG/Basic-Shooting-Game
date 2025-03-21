using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float speed;
    public float TimeToDestroy;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, TimeToDestroy); 
        aus = FindAnyObjectByType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // co 2 cach de thay doi va di chuyen vi tri cua 1 doi tuong
        //CACH 1: thay doi position trong thanh phan transform
        //CACH 2: dung phuong thuc Addforce cua thanh phan  rigidbody2d
        
        m_rb.velocity = Vector2.up * speed;  // (x,y) = (0,1)
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();

            if(aus != null && hitSound != null)
            {
                aus.PlayOneShot(hitSound);
            }
            Destroy(gameObject);
            Destroy(col.gameObject);

            Debug.Log("Da Ban Trung");
        }
    }
}
