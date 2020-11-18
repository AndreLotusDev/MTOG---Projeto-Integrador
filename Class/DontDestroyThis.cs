using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class DontDestroyThis : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> NotDestroy;
    private void Awake()
    {
        //Pega todos os itens q eu nao quero destruir
        NotDestroy.ForEach(f => DontDestroyOnLoad(f));
    }
}

