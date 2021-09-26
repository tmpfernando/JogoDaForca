using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajustes de tamanho e posi��o de acordo com o tamanho da tela ao ser instanciado
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 10);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -4 * Screen.height / 10);
    }

    // Update is called once per frame
    void Update() //caso o player pressione enter ou esc ser� feita a transi��o para a cena de introdu��o do jogo
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            OnClick();
        }
    }

    public void OnClick() //caso o bot�o seja acionado ser� feita a transi��o para a cena de introdu��o do jogo
    {
        SceneManager.LoadScene("Intro");
    }
}
