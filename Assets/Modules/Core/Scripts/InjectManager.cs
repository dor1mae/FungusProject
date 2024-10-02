using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InjectManager : MonoInstaller
{
    [SerializeField] private PlayerInput inputActions;
    [SerializeField] private Transform playerTransform;

    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>().FromInstance(inputActions);
        Container.Bind<Transform>().WithId("PlayerTransfrom").FromInstance(playerTransform);
    }
}
