using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BossHealthServiceInstaller", menuName = "Installers/BossHealthServiceInstaller")]
public class BossHealthServiceInstaller : ScriptableObjectInstaller<BossHealthServiceInstaller>
{
    public BossHealthSO bossHealthSO;
    public override void InstallBindings()
    {
        Container.BindInstance(bossHealthSO);
        Container.Bind<IBossHealthService>().To<BossHealthService>().AsSingle().NonLazy();

    }
}