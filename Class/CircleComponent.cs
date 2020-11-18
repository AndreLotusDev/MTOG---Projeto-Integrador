using Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Class
{
    public class CircleComponent : MonoBehaviour
    {
        //O circulo a ser controlado

        //Fazer retrabalho para melhorar desempenho futuramente
        [SerializeField]
        private GameObject PartCircle;

        //Qual a ordem 
        [SerializeField]
        private int Position;

        public void Awake()
        {
            PartCircle = this.gameObject;
        }

        //Pega a posição e retorna as demais classes
        public int getPosition()
        {
            return Position;
        }

        void Update()
        {

        }

        async void OnMouseDown()
        {
            if (GameController.Instance.AllowedToClick == false)
            {

            }
            else
            {
                if (GameController.Instance.CurrentGamePosition.Count > 0)
                {
                    int globalPosition = Position;

                    if (globalPosition == GameController.Instance.CurrentGamePosition[0])
                    {
                        GameController.Instance.CurrentGamePosition.RemoveAt(0);
                        GameController.Instance.playCorrectAsnwerSound();

                        Circle circle = GameObject.FindGameObjectWithTag("Circle").GetComponent<Circle>();

                        //Animação de clique
                        circle.enableDisableCircleRender(globalPosition);
                    }
                    else
                    {
                        GameController.Instance.playIncorrectAsnwerSound();
                        //Toca o audio de derrota
                        GameController.Instance.setClipSoud(SoundHolders.Instance.audioList["Loose"]);
                        //Espera um tempo para setar a tela de loose
                        await Utilities.awaitSomeTimeAsync(0.25f);
                        GameController.Instance.setYouLooseScreen();
                        GameController.Instance.AllowedToClick = false;
                    }

                    //WIN CONDITION
                    if (GameController.Instance.CurrentGamePosition.Count == 0)
                    {
                        //Seta a tela de win caso ele tenha eliminado todas as posições
                        await Utilities.awaitSomeTimeAsync(1);
                        GameController.Instance.setClipSoud(SoundHolders.Instance.audioList["Win"]);
                        await Utilities.awaitSomeTimeAsync(0.25f);
                        GameController.Instance.setYouWinScreen();

                        //Seta a nova pontuação
                        var Text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = "Pontuação: " + GameController.Instance.getCurrentLevel;
                    }
                }
            }
        }
    }
}
