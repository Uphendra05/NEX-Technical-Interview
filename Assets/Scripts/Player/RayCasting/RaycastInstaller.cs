using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "RaycastInstaller", menuName = "Installers/RaycastInstaller")]
public class RaycastInstaller : ScriptableObjectInstaller<RaycastInstaller>
{
    public RaycastSO raycastSO;
    public override void InstallBindings()
    {
        Container.BindInstance(raycastSO);
        Container.Bind<IRaycastService>().To<RaycastService>().AsSingle().NonLazy();


    }
}