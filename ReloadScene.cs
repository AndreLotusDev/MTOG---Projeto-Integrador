using UnityEngine.SceneManagement;
using UnityEngine;
using Assets.Scripts.Class;

namespace Assets.Scripts
{

    public class ReloadScene : MonoBehaviour
    {
        public void ReloadThis()
        {
            SceneManager.LoadScene("newMemoryGameLevel");

            //Reconfigura algumas variaveis importantes
            ImportantVariables.Start();
        }

        public void UpLevel()
        {
            GameController.Instance.getCurrentLevel++;
            GameController.Instance.Rounds = GameController.Instance.getCurrentLevel;
            GameController.Instance.timeToFadeOutCircles -= 0.3f;
        }

        public void getCurrentLevelAgain()
        {
            GameController.Instance.Rounds = GameController.Instance.getCurrentLevel;
        }
    }
}
