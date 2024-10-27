using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BossServiceInstaller", menuName = "Installers/BossServiceInstaller")]
public class BossServiceInstaller : ScriptableObjectInstaller<BossServiceInstaller>
{
    public BossSO bossScriptableObject;
    public BossView bossView;
    public override void InstallBindings()
    {
        Container.BindInstance(bossScriptableObject);
        Container.BindInstance(bossView);
        Container.Bind<IBossService>().To<BossService>().AsSingle().NonLazy();

    }
}