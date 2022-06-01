using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menü : MonoBehaviour
{
    public Text enskortext;
    public AudioSource menuses;
    public void Start()
    {
        enskortext.text = "En Yüksek Skor: " + (int)PlayerPrefs.GetFloat("enskor");
    }

    public void Başla()
    {
        SceneManager.LoadScene(1);
        menuses.Stop();
    }
    public void Menü()
    {
        SceneManager.LoadScene(0);
        menuses.Play();
    }
}