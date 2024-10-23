//using UnityEngine;
//using Zenject;

//[CreateAssetMenu(fileName = "WeaponServiceInstaller", menuName = "Installers/WeaponServiceInstaller")]
//public class WeaponServiceInstaller : ScriptableObjectInstaller<WeaponServiceInstaller>
//{

//    public WeaponSO WeaponSO;
//    public override void InstallBindings()
//    {
//        Container.BindInstance(WeaponSO);
//        Container.Bind<IWeaponService>().To<WeaponService>().AsSingle().NonLazy();
//    }
//}