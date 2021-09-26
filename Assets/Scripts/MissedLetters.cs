using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissedLetters : MonoBehaviour
{

    public string missedLetters; //este ser� um texto com as letras que foram acionadas, por�mm n�o est�o presentes na palavra oculta

    List<string> letterList; //esta ser� a lista de letras erradas
    List<KeyCode> permitInput; //esta ser� a lista de caracteres de entrada permitidos
    List<string> wordLetters; //esta ser� a lista de letras da palavra oculta

    // Start is called before the first frame update
    void Start()
    {
        PermitInputKeys(); //aqui chamamos um m�todo para preencher a lista de caracteres de entrada permitidos

        letterList = new List<string>(); //a lista de letras acionadas � instanciada

        LetterBehaviour.miss.AddListener(MissedLetter); //adicionamos o listener para o algoritmo saber quando ocorreu o evento de acionar a letra errada

        GetComponent<Text>().text = missedLetters.ToString(); //o texto deste objeto ser� preenchido com a informa��o presente no texto das letras erradas

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4); //ajuste de tamanho de acordo com a tela
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width - WordBehaviour.letterSize); //ajuste de tamanho de acordo com a tela

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - Screen.height / 3); //ajuste de posi��o de acordo com a tela

        wordLetters = new List<string>(); //instanciamos a lista de letras acionadas
        wordLetters.Clear(); //limpamos a lista para garantir que estar� vazia ao iniciar o c�digo

        for(int i = 0; i < WordBehaviour.word.Length; i++) //cada componente da palavra selecionada ser� adicionada para a lista com as letras desta palavra
        {
            wordLetters.Add(WordBehaviour.word[i].ToString());
        }

    }

    public void MissedLetter() //este m�todo � chamado quando o evento MISS ocorre (ou seja, quano o player digita uma letra errada)
    {
        if (letterList.Count > 9) //caso a quantidade de letras erradas seja maior que nove, ser� feita a transi��o para a cena de derrota
        {
            print("Perdeu!"); //simples conferencia atrav�s do console para saber se ocorreu a derrota
            SceneManager.LoadScene("Lost"); //m�todo para chamar a cena de derrota
        }
        else //enquanto n�o atingiou o crit�rio dos dez erros, as letras erradas ser�o listadas e colocadas na tela para o player saber
        {
            Event e = Event.current; //detectamos o input com este c�digo e � guardado na vari�vel e
            if (e.isKey) //caso o evento seja uma tecla do teclado entramos neste if
            {
                if (e.keyCode.ToString() != "None" && !wordLetters.Contains(e.keyCode.ToString()) && permitInput.Contains(e.keyCode)) //caso a letra n�o esteja retornando None, nem seja uma letra da palavra oculta e seja um caractere permitido para input
                {
                    if (!letterList.Contains(e.keyCode.ToString())) //se o caractere ainda n�o foi adicionado na lista
                    {
                        letterList.Add(e.keyCode.ToString()); //este caractere ser� adicionado na lista de letras erradas
                        missedLetters += e.keyCode.ToString() + " "; //a string com a lista de letras erradas � atualizada com a nova letra
                    }
                }
                GetComponent<Text>().text = "Letras Erradas: " + missedLetters.ToString() + "\nErros: " + letterList.Count + " de 10 permitidos"; //ent�o o elemento de texto mostrado na tela ser� atualizado
            }
        }
    }

    void PermitInputKeys() //este m�todo est� sendo usado para instanciar e preecher uma lista com as teclas permitidas
    {
        permitInput = new List<KeyCode>();

        permitInput.Clear(); //primeiramente limpamos a lista para garantir que n�o haver� erros

        permitInput.Add(KeyCode.A); //cada KeyCode ser� adicionado na lista
        permitInput.Add(KeyCode.B); //esta lista de verifica��o fo inecess�ria para imrpovisar uma solu��o para caracteres com acentos
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
