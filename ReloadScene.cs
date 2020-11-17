using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scripts.Class;

namespace Assets.Scripts
{

    class ReloadScene : MonoBehaviour
    {
        public void ReloadThis()
        {
            SceneManager.LoadScene("MemoryGame");

            //Reconfigura algumas variaveis importantes
            ImportantVariables.Start();
        }
    }
}
