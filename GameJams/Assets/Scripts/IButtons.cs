using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtons
{
    [SerializeField] IGameManager GameManager();
    void Retry();
}
