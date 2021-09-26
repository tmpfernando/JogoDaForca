using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordBehaviour : MonoBehaviour
{
    public static float letterSize; //tamanho da letra será calculado de acordo com o tamanho da tela
    public static string word; //palavra oculta selecionada para o jogo
    public static bool[] discoveredLetter; //vetor com a informação de quais letras foram descobertas
    public static string hint; //texto de dica para a palavra selecionada
    public static int wordIndex = 0; //indice usado em um laço de repetição
    public bool win; //variável com a informação do estado de vitória do jogo

    GameObject letterPrefab; //prefab para letras que serão instanciadas na tela
    GameObject hintPrefab; //prefab para o texto de dica que será instanciada na tela
    GameObject missedLettersPrefab; //prefab para o texto com a lista de letras erradas acionadas
    GameObject soundEffect; //prefab para o efeito de som

    // Start is called before the first frame update
    void Start()
    {
        SelectWord(); //chamada do método que seleciona uma palavra e a sua dica que estão no arquivo de texto

        discoveredLetter = new bool[word.Length]; //instancia do vetor com a informação de letras que foram descobertas

        for (int i = 0; i < word.Length; i++) //definindo que nenhuma letra foi descoberta ao iniciar o jogo
            discoveredLetter[i] = false;

        letterSize = Screen.width / (word.Length + 1); //calculo do tamanho do objeto das letras que serão instanciadas na tela

        letterPrefab = Resources.Load<GameObject>("Prefabs/Letter"); //atribuição do prefab na variável para que seja manipulada através do script
        hintPrefab = Resources.Load<GameObject>("Prefabs/Hint"); //atribuição do prefab na variável para que seja manipulada através do script
        missedLettersPrefab = Resources.Load<GameObject>("Prefabs/MissedLetters"); //atribuição do prefab na variável para que seja manipulada através do script
        soundEffect = Resources.Load<GameObject>("Prefabs/SoundEffect"); //atribuição do prefab na variável para que seja manipulada através do script

        hintPrefab.GetComponent<HintBehaviour>().hint = hint; //atribuição do texto da dica da palavra (extraído do arquivo) no texto do objeto da dica que aparece na tela

        float xPosition = letterSize - Screen.width / 2; //posição da primeira letra que será instanciada

        for (wordIndex = 0; wordIndex < word.Length; wordIndex++) //percorrer a string da palavra selecionada para instanciar as letras na tela
        {
            letterPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, 0); //correção da posição da letra atual
            xPosition += letterSize; //incremento da informação da posição para a próxima letra

            letterPrefab.GetComponent<Text>().text = "?"; //definição do texto mostrado na tela
            letterPrefab.name = "Letter" + wordIndex.ToString(); //atualização do nome do prefab com o índice da letra atual

            letterPrefab.GetComponent<LetterBehaviour>().letter = word[wordIndex]; //atribuição da variável que carrega a informação de qual é a letra correspondente no script do objeto da letra

            letterPrefab.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, letterSize); //atualização do tamanho horizontal da letra que será isntanciada
            letterPrefab.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, letterSize); //atualização do tamanho vertical da letra que será isntanciada

            Instantiate(letterPrefab, GameObject.Find("Word").transform); //após configurar o objeto, esta da letra é instanciada
        }

        Instantiate(hintPrefab, GameObject.Find("Word").transform); //a dica da palavra é instanciada na tela
        Instantiate(missedLettersPrefab, GameObject.Find("Word").transform); //a lista de letras erradas é instanciada na tela

    }

    // Update is called once per frame
    void Update()
    {
        win = VerifyWord(); //chamada do método que verifica se todas as letras já foram descobertas e atrobuição à variável win

        if (win) //caso a situação da vitória tenha ocorrido, será feita a transição para a tela da vitória
        {
            print("Ganhou");
            SceneManager.LoadScene("Win");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //Caso o player precione ESC, volta para a tela de introdução do jogo
        {
            print("Desistiu");
            SceneManager.LoadScene("Intro");
        }
    }

    void SelectWord() //Método utilizado para selecionar uma palavra aleatória no arquivo de texto
    {

        TextAsset textFile = Resources.Load<TextAsset>("TXT/Words"); //atribuição do arquivo de texto na variável para poder manipulá-lo aqui no script

        string[] wordBuffer = textFile.ToString().Split(new char[] {'\n'}); //cada linha do arquivo corresponde á uma palavra e sua dica, então o split é feito para separar as palavras em componentes de um vetor

        int selectedIndex = Mathf.RoundToInt(Random.Range(0, wordBuffer.Length)); //uma escolha aleatória entre 0 e o número máximo de componentes do buffer do texto é feita

        string[] selectedWord = wordBuffer[selectedIndex].Split(new char[] {'~'}); //atribuímos a palavra escolhida á uma variável local, o caractere ~ foi usado para separar a palavra da sua dica

        word = selectedWord[0].ToUpper(); //a variável que carrega a string da palavra selecionada é atualizada
        hint = selectedWord[1]; //a variável que carrega a dica da palavra selecionada é atualizada

    }

    public void VerifyLetter(string letter) //verificação para saber se a letra recebida neste método foi correta
    {
        for(int i = 0; i < word.Length; i++) //felizmente não está funcionado pois se estivesse ia disparar um efeito de audio para cada letra da palavra
        {
            if (word[i].ToString() == letter && !discoveredLetter[i])  //percorremos todas as letras da palavra verificando se foi o palpite certo, e se ainda não foi descoberta
            {
                discoveredLetter[i] = true; //caso seja correta, alterna a informação da discoberta da letra para true
                soundEffect.transform.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/hit"); //Instancia efeito de audio (mas não está funcionando)
                Instantiate(soundEffect);
            }
            else 
            {
                soundEffect.transform.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/miss"); //Instancia efeito de audio (mas não está funcionando)
                Instantiate(soundEffect);
            }
                
        }
    }

    public bool VerifyWord() //verificação se todas as componentes do vetor com a informação da descoberta das letras da palavra já estão com valor true
    {
        bool win = true; //inicialmente dizemos que win é true
        for (int i = 0; i < word.Length; i++) //um for para percorrer todas as componentes do vetor com a informação da descoberta de cada letra
        {
            if (discoveredLetter[i] == false) //caso esxista uma letra que ainda não foi descoberta
                win = false; // win recebe false
        }
        return win; //retornamos a informação se todas as letras da palavra foram descobertas
    }
}
