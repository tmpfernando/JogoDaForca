using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajustes de tamanho e posição de acordo com o tamanho da tela ao instanciar o objeto
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 10);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -4 * Screen.height / 10);
    }

    // Update is called once per frame
    void Update() //caso o player apertar ENTER o botão de iniciar o jogo será acionado
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClick();
        }
    }

    public void OnClick() //caso o botão seja acionado, será feita a transição para a cena do jogo
    {
        SceneManager.LoadScene("Playing");
    }
}
