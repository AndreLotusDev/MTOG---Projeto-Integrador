using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Class
{
    public class GameOver: MonoBehaviour
    {
        private void Awake()
        {
            //Evita q ele seja destruido
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
