﻿using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Services.Factories.PrefabFactory
{
    public interface IPrefabFactory
    {
        UniTask<T> Create<T>() where T : MonoBehaviour;
    }
}