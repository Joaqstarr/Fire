using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balllog : MonoBehaviour
{
    int x = 0;
    Rigidbody m_ball;
    [SerializeField]private float upward = 2000f;
    
    // Start is called before the first frame update
    void Start()
    {
        m_ball = GetComponent<Rigidbody>();



    }
    void OnCollisionEnter(Collision collision)
    {
        x += 1;
        Debug.Log("the ball has collided " + x + "times.");
        //GameObject m_plane = collision.gameObject;
        Debug.Log("the ball has collided with a " + collision.gameObject.name);
        
        m_ball.AddForce(transform.up * upward,ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
