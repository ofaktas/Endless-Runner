using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class olummenu : MonoBehaviour
{
    public Text SkorText;
    public AudioSource ses;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void ToggleEndMenu(float skor)
    {
        gameObject.SetActive(true);
        SkorText.text = ((int)skor).ToString();
    }
    public void Tekrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menü()
    {
        SceneManager.LoadScene(0);
        ses.Play();
    }
}
