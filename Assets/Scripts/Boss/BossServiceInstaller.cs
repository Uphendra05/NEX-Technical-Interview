using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BossServiceInstaller", menuName = "Installers/BossServiceInstaller")]
public class BossServiceInstaller : ScriptableObjectInstaller<BossServiceInstaller>
{
    public BossSO bossScriptableObject;
    public override void InstallBindings()
    {
        Container.BindInstance(bossScriptableObject);
        Container.Bind<IBossService>().To<BossService>().AsSingle().NonLazy();

    }
}