using System.Collections.Generic;
using Unity;
using UnityEngine;

namespace Assets.Scripts.Class
{
    public class SoundHolders : MonoBehaviour
    {
        public static SoundHolders Instance { get; private set; }

        //Chave e valor para as outras instancias acharem tais objetos
        [SerializeField]
        List<string> stringKeys;

        [SerializeField]
        List<AudioClip> AudioClipValues;

        public Dictionary<string, AudioClip> audioList = new Dictionary<string, AudioClip>();

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

            //Adiciona a key juntamente com o proprio audio
            foreach(var item in stringKeys)
            {
                audioList.Add(item, AudioClipValues[stringKeys.IndexOf(item)]);
            }   
        }
    }
}
