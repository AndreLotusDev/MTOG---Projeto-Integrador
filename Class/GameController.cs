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
    //Tempo para que cada circulo pisque
    public float timeToFadeOutCircles { get; set; }

    #region Sounds
    //Som de resposta correta
    [SerializeField]
    private AudioSource CorrectAsnwerSound;

    //Som de resposta incorreta
    [SerializeField]
    private AudioSource incorrectAsnwerSound;

    public GameObject SoundController { get; set; }

    [SerializeField]
    public AudioClip BipSound;
    #endregion

    #region WinLoose
    //Imagem de voce ganhou!!
    public GameObject YouWin { get; set; }

    public GameObject YouLoose { get; set; }
    #endregion

    public int getCurrentLevel { get; set; }

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
        YouLoose = GameObject.FindGameObjectWithTag("Loose");

        YouWin.SetActive(false);
        YouLoose.SetActive(false);

        //Instanciação da controller do jogo

        SoundController = GameObject.FindGameObjectWithTag("SoundController");

        //Player Config
        AllowedToClick = false;

        //Rounds Inicias, depois alterar
        getCurrentLevel = 1;
        Rounds = getCurrentLevel;

        //Tempo inicial
        timeToFadeOutCircles = 2.0f;
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

    public void playSound()
    {
        SoundController.GetComponent<AudioSource>().Play();
    }

    //Seta e toca a musica na controller
    public void setClipSoud(AudioClip ac)
    {
        SoundController.GetComponent<AudioSource>().clip = ac;
        SoundController.GetComponent<AudioSource>().Play();
    }


    public void playBipSound()
    {
        SoundController.GetComponent<AudioSource>().clip = BipSound;
        SoundController.GetComponent<AudioSource>().Play();
    }
}
