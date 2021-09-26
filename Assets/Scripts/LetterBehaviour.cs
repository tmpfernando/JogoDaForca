using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LetterBehaviour : MonoBehaviour
{
    public Vector2 initialPosition; //este vetor será manipulado para calcular a posição das letras na tela

    public static UnityEvent hit; //este evento será acionado quando o player acertar alguma letra oculta
    public static UnityEvent miss; //este evento será acionado quando o player errar uma letra oculta

    public float size = 0; //esta variável será calculada para definir um tamanho de altura e largura da letra conforme o tamanho da tela

    public char letter; //esta variável receberá o valor da letra que este objeto representa

    private void Awake()
    {
        hit = new UnityEvent(); //instanciando o evento
        miss = new UnityEvent(); //instanciando o evento
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0); //Inicialmente o tamanho será zero

        initialPosition = GetComponent<RectTransform>().anchoredPosition; //posição inicial da letra

        if(letter.ToString() == "'" || letter.ToString() == "-") 
        {
            GetComponent<Text>().text = letter.ToString();
            GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<RectTransform>().sizeDelta.y < WordBehaviour.letterSize) //caso o tamanho da letra seja menor que o calculado
        {
            size += 200 * Time.deltaTime; //a variável size recebe um incremento
            GetComponent<RectTransform>().sizeDelta = new Vector2(size, size); //então o tamanho da letra é atualizado, desta forma temos um efeito da letra aumentando de tamanho, até o tamanho certo, quando é instanciada
        }

    }

    void OnGUI()
    {
        if (Input.anyKeyDown) //caso alguma tecla seja acionada
        {
            Event e = Event.current; //capturamos a tecla e as informações sobre ela ficam guardadasm na variável

            Debug.Log("Detected key code: " + e.keyCode); //simples conferencia através do console para saber se a detecção está funcionando

            //A partir deste trecho, temos uma solução improvisada para o uso de caracteres especiais
            if (e.character.ToString() == "A" || e.character.ToString() == "a") //caso seja acionada a tecla A
            {
                if((letter.ToString() == "Á") || (letter.ToString() == "À") || (letter.ToString() == "Ã") || (letter.ToString() == "Â") || (letter.ToString() == "Ä")) //verifica-se se a letra é um caractere com acento
                {
                    GetComponent<Text>().text = letter.ToString(); //caso seja, ocaractere mostrado na tela será atualizado de ? para o caractere descoberto
                    hit?.Invoke(); //então o evento HIT será invocado, significa que o player acertou uma letra
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString()); //este caractere será enviado para outro script que confere se a plalavra já foi descoberta
                }
            }
            else if (e.character.ToString() == "E" || e.character.ToString() == "e") //analogamente o anterior, porém para a letra E
            {
                if ((letter.ToString() == "É") || (letter.ToString() == "È") || (letter.ToString() == "Ê") || (letter.ToString() == "Ê") || (letter.ToString() == "Ë"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "I" || e.character.ToString() == "i") //analogamente o anterior, porém para a letra I
            {
                if ((letter.ToString() == "Í") || (letter.ToString() == "Ì") || (letter.ToString() == "~E") || (letter.ToString() == "Î") || (letter.ToString() == "Ï"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "O" || e.character.ToString() == "o") //analogamente o anterior, porém para a letra O
            {
                if ((letter.ToString() == "Ó") || (letter.ToString() == "Ò") || (letter.ToString() == "Õ") || (letter.ToString() == "Ô") || (letter.ToString() == "Ö"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "U" || e.character.ToString() == "u") //analogamente o anterior, porém para a letra U
            {
                if ((letter.ToString() == "Ú") || (letter.ToString() == "Ù") || (letter.ToString() == "~U") || (letter.ToString() == "Û") || (letter.ToString() == "Ü"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "C" || e.character.ToString() == "c") //analogamente o anterior, porém para a letra Ç
            {
                if ((letter.ToString() == "Ç"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }else if (e.keyCode.ToString() == letter.ToString()) //caso a letra não seja um caractere especial, verifica-se se a tecla acionada corresponde à letra que este objeto representa
            {
                GetComponent<Text>().text = letter.ToString(); //se coincidir com a letra deste objeto, o caractere ? será atualizado para a letra deste objeto
                hit?.Invoke(); //o evento HIT será acionado
                GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString()); //esta letra será enviada para outro script que verifica se a plalavra já foi descoberta
            }
            else //caso a letra acionada não corresponda com a letra que este objeto representa, o evento MISS será acionado
            {
                miss?.Invoke();
            }
        }
        
    }
}
