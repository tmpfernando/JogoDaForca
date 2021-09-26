using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //este comando � para que este objeto que fica tocando a musica de background n�o seja deletado nas trocas de cena
    }

    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindGameObjectsWithTag("music").Length > 1) //uma verifica��o simples para impedir que este objeto seja instanciado duas vezes, j� que ele n�o ser� destru�do na troca das cenas
        {
            Object.Destroy(gameObject); //caso j� exista um no jogo, a instancia deste objeto ser� removida
        }
        else
        {
            if (PlayerPrefs.GetFloat("musicVolume") == 0) //caso seja a primeira vez que o player esteja abrindo o jogo, este float vale zero
            {
                GetComponent<AudioSource>().volume = 0.5f; //ent�o definimos o volume em 50%
            }
            else
            {
                GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume"); //caso o player j� tenha aberto o jogo, carregaremos o volume que ele configurou
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //caso apertar a seta para cima
        {
            GetComponent<AudioSource>().volume += 0.05f; //o volume � incrementado em 5% e a informa��o � salva atrav�s da classe playerprefs
            PlayerPrefs.SetFloat("musicVolume", GetComponent<AudioSource>().volume);
            PlayerPrefs.Save();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) //caso apertar a seta para baixo
        {
            GetComponent<AudioSource>().volume -= 0.05f; //o volume � decrementado em 5% e a informa��o � salva atrav�s da classe playerprefs
            PlayerPrefs.SetFloat("musicVolume", GetComponent<AudioSource>().volume);
            PlayerPrefs.Save();
        }
    }
}
