using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class titletogame : MonoBehaviour
{

    AudioSource m_audiosource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiter());

        m_audiosource = GetComponent<AudioSource>();


    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(2);

        m_audiosource.Play();


    }
    


    



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene(sceneBuildIndex: 1);

        }
    }
