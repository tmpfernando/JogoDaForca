using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissedLetters : MonoBehaviour
{

    public string missedLetters; //este será um texto com as letras que foram acionadas, porémm não estão presentes na palavra oculta

    List<string> letterList; //esta será a lista de letras erradas
    List<KeyCode> permitInput; //esta será a lista de caracteres de entrada permitidos
    List<string> wordLetters; //esta será a lista de letras da palavra oculta

    // Start is called before the first frame update
    void Start()
    {
        PermitInputKeys(); //aqui chamamos um método para preencher a lista de caracteres de entrada permitidos

        letterList = new List<string>(); //a lista de letras acionadas é instanciada

        LetterBehaviour.miss.AddListener(MissedLetter); //adicionamos o listener para o algoritmo saber quando ocorreu o evento de acionar a letra errada

        GetComponent<Text>().text = missedLetters.ToString(); //o texto deste objeto será preenchido com a informação presente no texto das letras erradas

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4); //ajuste de tamanho de acordo com a tela
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width - WordBehaviour.letterSize); //ajuste de tamanho de acordo com a tela

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - Screen.height / 3); //ajuste de posição de acordo com a tela

        wordLetters = new List<string>(); //instanciamos a lista de letras acionadas
        wordLetters.Clear(); //limpamos a lista para garantir que estará vazia ao iniciar o código

        for(int i = 0; i < WordBehaviour.word.Length; i++) //cada componente da palavra selecionada será adicionada para a lista com as letras desta palavra
        {
            wordLetters.Add(WordBehaviour.word[i].ToString());
        }

    }

    public void MissedLetter() //este método é chamado quando o evento MISS ocorre (ou seja, quano o player digita uma letra errada)
    {
        if (letterList.Count > 9) //caso a quantidade de letras erradas seja maior que nove, será feita a transição para a cena de derrota
        {
            print("Perdeu!"); //simples conferencia através do console para saber se ocorreu a derrota
            SceneManager.LoadScene("Lost"); //método para chamar a cena de derrota
        }
        else //enquanto não atingiou o critério dos dez erros, as letras erradas serão listadas e colocadas na tela para o player saber
        {
            Event e = Event.current; //detectamos o input com este código e é guardado na variável e
            if (e.isKey) //caso o evento seja uma tecla do teclado entramos neste if
            {
                if (e.keyCode.ToString() != "None" && !wordLetters.Contains(e.keyCode.ToString()) && permitInput.Contains(e.keyCode)) //caso a letra não esteja retornando None, nem seja uma letra da palavra oculta e seja um caractere permitido para input
                {
                    if (!letterList.Contains(e.keyCode.ToString())) //se o caractere ainda não foi adicionado na lista
                    {
                        letterList.Add(e.keyCode.ToString()); //este caractere será adicionado na lista de letras erradas
                        missedLetters += e.keyCode.ToString() + " "; //a string com a lista de letras erradas é atualizada com a nova letra
                    }
                }
                GetComponent<Text>().text = "Letras Erradas: " + missedLetters.ToString() + "\nErros: " + letterList.Count + " de 10 permitidos"; //então o elemento de texto mostrado na tela será atualizado
            }
        }
    }

    void PermitInputKeys() //este método está sendo usado para instanciar e preecher uma lista com as teclas permitidas
    {
        permitInput = new List<KeyCode>();

        permitInput.Clear(); //primeiramente limpamos a lista para garantir que não haverá erros

        permitInput.Add(KeyCode.A); //cada KeyCode será adicionado na lista
        permitInput.Add(KeyCode.B); //esta lista de verificação fo inecessária para imrpovisar uma solução para caracteres com acentos
        permitInput.Add(KeyCode.C);
        permitInput.Add(KeyCode.D);
        permitInput.Add(KeyCode.E);
        permitInput.Add(KeyCode.F);
        permitInput.Add(KeyCode.G);
        permitInput.Add(KeyCode.H);
        permitInput.Add(KeyCode.I);
        permitInput.Add(KeyCode.J);
        permitInput.Add(KeyCode.K);
        permitInput.Add(KeyCode.L);
        permitInput.Add(KeyCode.M);
        permitInput.Add(KeyCode.N);
        permitInput.Add(KeyCode.O);
        permitInput.Add(KeyCode.P);
        permitInput.Add(KeyCode.Q);
        permitInput.Add(KeyCode.R);
        permitInput.Add(KeyCode.S);
        permitInput.Add(KeyCode.T);
        permitInput.Add(KeyCode.U);
        permitInput.Add(KeyCode.V);
        permitInput.Add(KeyCode.W);
        permitInput.Add(KeyCode.X);
        permitInput.Add(KeyCode.Y);
        permitInput.Add(KeyCode.Z);
    }

}
