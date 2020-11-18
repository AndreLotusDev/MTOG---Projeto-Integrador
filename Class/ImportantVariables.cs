using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts.Class
{
    public class ImportantVariables : MonoBehaviour
    {
        //Colocar aqui todas as variaveis que sao importantes ao dar reload na cena

        static public void Start()
        {
            //GameController.Instance.YouWin = GameObject.FindGameObjectWithTag("Win");

            //GameController.Instance.YouLoose = GameObject.FindGameObjectWithTag("Loose");

            GameController.Instance.YouWin.SetActive(false);
            GameController.Instance.YouLoose.SetActive(false);

            GameController.Instance.AllowedToClick = false;
            //Limpa todas os elementos da lista
            GameController.Instance.CurrentGamePosition.Clear();
        }
    }
}
