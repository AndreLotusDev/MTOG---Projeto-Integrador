using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Class
{
    public class Utilities
    {
        //Classe generica pra poder esperar x tempo
        async static public Task awaitSomeTimeAsync(double time)
        {
            await Task.Delay(TimeSpan.FromSeconds(time));
        }

    }
}
