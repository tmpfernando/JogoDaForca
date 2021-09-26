using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordBehaviour : MonoBehaviour
{
    public static float letterSize; //tamanho da letra ser� calculado de acordo com o tamanho da tela
    public static string word; //palavra oculta selecionada para o jogo
    public static bool[] discoveredLetter; //vetor com a informa��o de quais letras foram descobertas
    public static string hint; //texto de dica para a palavra selecionada
    public static int wordIndex = 0; //indice usado em um la�o de repeti��o
    public bool win; //vari�vel com a informa��o do estado de vit�ria do jogo

    GameObject letterPrefab; //prefab para letras que ser�o instanciadas na tela
    GameObject hintPrefab; //prefab para o texto de dica que ser� instanciada na tela
    GameObject missedLettersPrefab; //prefab para o texto com a lista de letras erradas acionadas
    GameObject soundEffect; //prefab para o efeito de som

    // Start is called before the first frame update
    void Start()
    {
        SelectWord(); //chamada do m�todo que seleciona uma palavra e a sua dica que est�o no arquivo de texto

        discoveredLetter = new bool[word.Length]; //instancia do vetor com a informa��o de letras que foram descobertas

        for (int i = 0; i < word.Length; i++) //definindo que nenhuma letra foi descoberta ao iniciar o jogo
            discoveredLetter[i] = false;

        letterSize = Screen.width / (word.Length + 1); //calculo do tamanho do objeto das letras que ser�o instanciadas na tela

        letterPrefab = Resources.Load<GameObject>("Prefabs/Letter"); //atribui��o do prefab na vari�vel para que seja manipulada atrav�s do script
        hintPrefab = Resources.Load<GameObject>("Prefabs/Hint"); //atribui��o do prefab na vari�vel para que seja manipulada atrav�s do script
        missedLettersPrefab = Resources.Load<GameObject>("Prefabs/MissedLetters"); //atribui��o do prefab na vari�vel para que seja manipulada atrav�s do script
        soundEffect = Resources.Load<GameObject>("Prefabs/SoundEffect"); //atribui��o do prefab na vari�vel para que seja manipulada atrav�s do script

        hintPrefab.GetComponent<HintBehaviour>().hint = hint; //atribui��o do texto da dica da palavra (extra�do do arquivo) no texto do objeto da dica que aparece na tela

        float xPosition = letterSize - Screen.width / 2; //posi��o da primeira letra que ser� instanciada

        for (wordIndex = 0; wordIndex < word.Length; wordIndex++) //percorrer a string da palavra selecionada para instanciar as letras na tela
        {
            letterPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, 0); //corre��o da posi��o da letra atual
            xPosition += letterSize; //incremento da informa��o da posi��o para a pr�xima letra

            letterPrefab.GetComponent<Text>().text = "?"; //defini��o do texto mostrado na tela
            letterPrefab.name = "Letter" + wordIndex.ToString(); //atualiza��o do nome do prefab com o �ndice da letra atual

            letterPrefab.GetComponent<LetterBehaviour>().letter = word[wordIndex]; //atribui��o da vari�vel que carrega a informa��o de qual � a letra correspondente no script do objeto da letra

            letterPrefab.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, letterSize); //atualiza��o do tamanho horizontal da letra que ser� isntanciada
            letterPrefab.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, letterSize); //atualiza��o do tamanho vertical da letra que ser� isntanciada

            Instantiate(letterPrefab, GameObject.Find("Word").transform); //ap�s configurar o objeto, esta da letra � instanciada
        }

        Instantiate(hintPrefab, GameObject.Find("Word").transform); //a dica da palavra � instanciada na tela
        Instantiate(missedLettersPrefab, GameObject.Find("Word").transform); //a lista de letras erradas � instanciada na tela

    }

    // Update is called once per frame
    void Update()
    {
        win = VerifyWord(); //chamada do m�todo que verifica se todas as letras j� foram descobertas e atrobui��o � vari�vel win

        if (win) //caso a situa��o da vit�ria tenha ocorrido, ser� feita a transi��o para a tela da vit�ria
        {
            print("Ganhou");
            SceneManager.LoadScene("Win");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Caso o player precione ESC, volta para a tela de introdu��o do jogo
        {
            print("Desistiu");
            SceneManager.LoadScene("Intro");
        }
    }

    void SelectWord() //M�todo utilizado para selecionar uma palavra aleat�ria no arquivo de texto
    {

        TextAsset textFile = Resources.Load<TextAsset>("TXT/Words"); //atribui��o do arquivo de texto na vari�vel para poder manipul�-lo aqui no script

        string[] wordBuffer = textFile.ToString().Split(new char[] {'\n'}); //cada linha do arquivo corresponde � uma palavra e sua dica, ent�o o split � feito para separar as palavras em componentes de um vetor

        int selectedIndex = Mathf.RoundToInt(Random.Range(0, wordBuffer.Length)); //uma escolha aleat�ria entre 0 e o n�mero m�ximo de componentes do buffer do texto � feita

        string[] selectedWord = wordBuffer[selectedIndex].Split(new char[] {'~'}); //atribu�mos a palavra escolhida � uma vari�vel local, o caractere ~ foi usado para separar a palavra da sua dica

        word = selectedWord[0].ToUpper(); //a vari�vel que carrega a string da palavra selecionada � atualizada
        hint = selectedWord[1]; //a vari�vel que carrega a dica da palavra selecionada � atualizada

    }

    public void VerifyLetter(string letter) //verifica��o para saber se a letra recebida neste m�todo foi correta
    {
        for(int i = 0; i < word.Length; i++) //felizmente n�o est� funcionado pois se estivesse ia disparar um efeito de audio para cada letra da palavra
        {
            if (word[i].ToString() == letter && !discoveredLetter[i])  //percorremos todas as letras da palavra verificando se foi o palpite certo, e se ainda n�o foi descoberta
            {
                discoveredLetter[i] = true; //caso seja correta, alterna a informa��o da discoberta da letra para true
                soundEffect.transform.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/hit"); //Instancia efeito de audio (mas n�o est� funcionando)
                Instantiate(soundEffect);
            }
            else 
            {
                soundEffect.transform.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/miss"); //Instancia efeito de audio (mas n�o est� funcionando)
                Instantiate(soundEffect);
            }
                
        }
    }

    public bool VerifyWord() //verifica��o se todas as componentes do vetor com a informa��o da descoberta das letras da palavra j� est�o com valor true
    {
        bool win = true; //inicialmente dizemos que win � true
        for (int i = 0; i < word.Length; i++) //um for para percorrer todas as componentes do vetor com a informa��o da descoberta de cada letra
        {
            if (discoveredLetter[i] == false) //caso esxista uma letra que ainda n�o foi descoberta
                win = false; // win recebe false
        }
        return win; //retornamos a informa��o se todas as letras da palavra foram descobertas
    }
}
