using Assets.Scripts.Class;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Circle : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> circleList = new List<GameObject>();

    [SerializeField]
    private List<SpriteRenderer> circleListRender = new List<SpriteRenderer>();

    // Start is called before the first frame update
    void Start()
    {       
        //Desativa os itens no começo do jogo
        foreach (var circles in circleListRender)
        {
            circles.enabled = false;
        }

        //Codigo assincrono
        StartCoroutine(WaitToSetActive(2.0f));

    }

    // Update is called once per frame
    void Update()
    {
        //Implementar os cliques so apos de ter sorteado a rodada

        //Pega a peça atual que foi clicada
    }

    private IEnumerator WaitToSetActive(float time)
    {
        while (GameController.Instance.Rounds != 0)
        {
            //Reduz uma rodada do jogo
            GameController.Instance.Rounds -= 1;

            yield return new WaitForSeconds(time);

            //Seleciona um pedaço do circulo para poder piscar
            int selectedPiece = UnityEngine.Random.Range(0, 4);

            foreach (var circles in circleListRender)
            {
                int actualPosition = circles.GetComponent<CircleComponent>().getPosition();

                if (actualPosition == selectedPiece)
                {
                    circles.enabled = true;
                    //Espera mais um pouco
                    yield return new WaitForSeconds(time / 2);
                    circles.enabled = false;

                    GameController.Instance.CurrentGamePosition.Add(actualPosition);

                    //Debugger
                    if (GameController.Instance.Rounds == 0)
                        GameController.Instance.CurrentGamePosition.ForEach(f => Debug.Log(f));
                }
            }

            if(GameController.Instance.Rounds == 0)
            {
                GameController.Instance.AllowedToClick = true;
            }
        }
    }
}
