using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "CameraServiceInstaller", menuName = "Installers/CameraServiceInstaller")]
public class CameraServiceInstaller : ScriptableObjectInstaller<CameraServiceInstaller>
{

    public CameraSO cameraSO;
    public override void InstallBindings()
    {
        Container.BindInstance(cameraSO);
        Container.Bind<ICameraService>().To<CameraService>().AsSingle().NonLazy();

    }
}