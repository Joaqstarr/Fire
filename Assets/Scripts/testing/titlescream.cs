using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class titlescream : MonoBehaviour
{

    AudioSource m_audiosource;
    [SerializeField] private Transform _darkness;
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
        Destroy(_darkness.gameObject);


    }







    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);

        }
    }
}
