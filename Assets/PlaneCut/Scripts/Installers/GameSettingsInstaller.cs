using UnityEngine;
using Zenject;

namespace PlaneCut
{
	[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
	{
		public MeshCreator.Settings MeshSettings;
		public LineConstructer.Settings LineSettings;
		public DistanceSetter.Settings DistanceSettings;
		public MeshCutInstaller.Settings MeshCutSettings;
		public PlayerMovement.Settings MovementSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(MeshSettings);
			Container.BindInstance(LineSettings);
			Container.BindInstance(DistanceSettings);
			Container.BindInstance(MeshCutSettings);
			Container.BindInstance(MovementSettings);
		}
	}
}