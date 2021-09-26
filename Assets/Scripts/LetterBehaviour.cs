using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LetterBehaviour : MonoBehaviour
{
    public Vector2 initialPosition; //este vetor ser� manipulado para calcular a posi��o das letras na tela

    public static UnityEvent hit; //este evento ser� acionado quando o player acertar alguma letra oculta
    public static UnityEvent miss; //este evento ser� acionado quando o player errar uma letra oculta

    public float size = 0; //esta vari�vel ser� calculada para definir um tamanho de altura e largura da letra conforme o tamanho da tela

    public char letter; //esta vari�vel receber� o valor da letra que este objeto representa

    private void Awake()
    {
        hit = new UnityEvent(); //instanciando o evento
        miss = new UnityEvent(); //instanciando o evento
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0); //Inicialmente o tamanho ser� zero

        initialPosition = GetComponent<RectTransform>().anchoredPosition; //posi��o inicial da letra

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
            size += 200 * Time.deltaTime; //a vari�vel size recebe um incremento
            GetComponent<RectTransform>().sizeDelta = new Vector2(size, size); //ent�o o tamanho da letra � atualizado, desta forma temos um efeito da letra aumentando de tamanho, at� o tamanho certo, quando � instanciada
        }

    }

    void OnGUI()
    {
        if (Input.anyKeyDown) //caso alguma tecla seja acionada
        {
            Event e = Event.current; //capturamos a tecla e as informa��es sobre ela ficam guardadasm na vari�vel

            Debug.Log("Detected key code: " + e.keyCode); //simples conferencia atrav�s do console para saber se a detec��o est� funcionando

            //A partir deste trecho, temos uma solu��o improvisada para o uso de caracteres especiais
            if (e.character.ToString() == "A" || e.character.ToString() == "a") //caso seja acionada a tecla A
            {
                if((letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�")) //verifica-se se a letra � um caractere com acento
                {
                    GetComponent<Text>().text = letter.ToString(); //caso seja, ocaractere mostrado na tela ser� atualizado de ? para o caractere descoberto
                    hit?.Invoke(); //ent�o o evento HIT ser� invocado, significa que o player acertou uma letra
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString()); //este caractere ser� enviado para outro script que confere se a plalavra j� foi descoberta
                }
            }
            else if (e.character.ToString() == "E" || e.character.ToString() == "e") //analogamente o anterior, por�m para a letra E
            {
                if ((letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "I" || e.character.ToString() == "i") //analogamente o anterior, por�m para a letra I
            {
                if ((letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "~E") || (letter.ToString() == "�") || (letter.ToString() == "�"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "O" || e.character.ToString() == "o") //analogamente o anterior, por�m para a letra O
            {
                if ((letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "�"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "U" || e.character.ToString() == "u") //analogamente o anterior, por�m para a letra U
            {
                if ((letter.ToString() == "�") || (letter.ToString() == "�") || (letter.ToString() == "~U") || (letter.ToString() == "�") || (letter.ToString() == "�"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }
            else if (e.character.ToString() == "C" || e.character.ToString() == "c") //analogamente o anterior, por�m para a letra �
            {
                if ((letter.ToString() == "�"))
                {
                    GetComponent<Text>().text = letter.ToString();
                    hit?.Invoke();
                    GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString());
                }
            }else if (e.keyCode.ToString() == letter.ToString()) //caso a letra n�o seja um caractere especial, verifica-se se a tecla acionada corresponde � letra que este objeto representa
            {
                GetComponent<Text>().text = letter.ToString(); //se coincidir com a letra deste objeto, o caractere ? ser� atualizado para a letra deste objeto
                hit?.Invoke(); //o evento HIT ser� acionado
                GameObject.Find("Word").GetComponent<WordBehaviour>().VerifyLetter(letter.ToString()); //esta letra ser� enviada para outro script que verifica se a plalavra j� foi descoberta
            }
            else //caso a letra acionada n�o corresponda com a letra que este objeto representa, o evento MISS ser� acionado
            {
                miss?.Invoke();
            }
        }
        
    }
}
