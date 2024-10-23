using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DITestInstaller", menuName = "Installers/DITestInstaller")]
public class DITestInstaller : ScriptableObjectInstaller<DITestInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IDITestService>().To<DITestService>().AsSingle().NonLazy();
    }
}