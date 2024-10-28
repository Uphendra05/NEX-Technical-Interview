using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerHealthInstaller", menuName = "Installers/PlayerHealthInstaller")]
public class PlayerHealthInstaller : ScriptableObjectInstaller<PlayerHealthInstaller>
{

    public PlayerHealthSO playerHealthSO;
    public override void InstallBindings()
    {

        Container.BindInstance(playerHealthSO);
        Container.Bind<IPlayerHealthService>().To<PlayerHealthService>().AsSingle().NonLazy();

    }
}