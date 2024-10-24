using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BossServiceInstaller", menuName = "Installers/BossServiceInstaller")]
public class BossServiceInstaller : ScriptableObjectInstaller<BossServiceInstaller>
{
    public override void InstallBindings()
    {

        Container.Bind<IBossService>().To<BossService>().AsSingle().NonLazy();

    }
}