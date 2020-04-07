using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        source.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        source.Play();
        Application.Quit();
    }
}
