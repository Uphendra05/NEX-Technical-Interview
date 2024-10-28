using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UiServiceInstaller", menuName = "Installers/UiServiceInstaller")]
public class UiServiceInstaller : ScriptableObjectInstaller<UiServiceInstaller>
{
    public override void InstallBindings()
    {

        Container.Bind<IUiService>().To<UiService>().AsSingle().NonLazy();
    }
}