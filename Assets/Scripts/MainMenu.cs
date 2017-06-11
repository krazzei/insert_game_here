using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource MainTheme;
    public Image Title;
    public AudioSource GameMusic;
    private bool _isOn = true;

    private void Start()
    {
        StartCoroutine(ShowTitle());
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(1.0f);
        Title.enabled = true;
        MainTheme.Play();
    }

    private void Update()
    {
        if(!_isOn)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TestLevel");
            MainTheme.Stop();
            GameMusic.Play();
            _isOn = false;
        }
    }

}
