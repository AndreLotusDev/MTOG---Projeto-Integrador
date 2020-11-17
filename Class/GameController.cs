using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Padrao SINGLETON
    public static GameController Instance { get; private set; }

    //Pega a posição atual
    public int PositionNowClicked { get; set; }

    //Pega as posições atual do jogo
    public List<int> CurrentGamePosition { get; set; }

    //Verifica se o player pode clicar
    public bool AllowedToClick { get; set; }

    //Numero de rounds
    public int Rounds {get; set;}

    #region Sounds
    //Som de resposta correta
    [SerializeField]
    private AudioSource CorrectAsnwerSound;

    //Som de resposta incorreta
    [SerializeField]
    private AudioSource incorrectAsnwerSound;
    #endregion

    #region WinLoose
    //Imagem de voce ganhou!!
    public GameObject YouWin { get; set; }

    public GameObject YouLoose { get; set; }
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Instanciação de valores
        PositionNowClicked = 0;
        CurrentGamePosition = new List<int>();

        //Instanciação Win-Loose
        YouWin = GameObject.FindGameObjectWithTag("Win");
        YouLoose= GameObject.FindGameObjectWithTag("Loose");

        YouWin.SetActive(false);
        YouLoose.SetActive(false);

        //Player Config
        AllowedToClick = false;

        //Rounds Inicias, depois alterar
        Rounds = 3;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    //Verifica se o player acertou o circulo correto
    public void playCorrectAsnwerSound()
    {
        CorrectAsnwerSound.Play();
    }
    //Caso erre
    public void playIncorrectAsnwerSound()
    {
        incorrectAsnwerSound.Play();
    }
    //Caso vc ganhe ou perca sete tais telas
    public void setYouWinScreen()
    {
        YouWin.SetActive(true);
    }
    public void setYouLooseScreen()
    {
        YouLoose.SetActive(true);
    }
}
