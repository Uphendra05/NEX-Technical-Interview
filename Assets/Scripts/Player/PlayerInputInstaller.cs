using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerInputInstaller", menuName = "Installers/PlayerInputInstaller")]
public class PlayerInputInstaller : ScriptableObjectInstaller<PlayerInputInstaller>
{
    public override void InstallBindings()
    {

        Container.Bind<IPlayerInputService>().To<PlayerInputService>().AsSingle().NonLazy();
    }
}