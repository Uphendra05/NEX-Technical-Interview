using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TurretServiceInstaller", menuName = "Installers/TurretServiceInstaller")]
public class TurretServiceInstaller : ScriptableObjectInstaller<TurretServiceInstaller>
{

    public TurretSO turretScriptableObject;
    public override void InstallBindings()
    {
        Container.BindInstance(turretScriptableObject);
        Container.Bind<ITurretService>().To<TurretService>().AsSingle().NonLazy();

    }
}