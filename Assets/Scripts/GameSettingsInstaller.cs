using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public MeshCreator.Settings meshSettings;
    public LineConstructer.Settings lineSettings;
    public DistanceSetter.Settings distanceSettings;
    public MeshCutInstaller.Settings meshCutSettings;
    public PlayerMovement.Settings movementSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(meshSettings);
        Container.BindInstance(lineSettings);
        Container.BindInstance(distanceSettings);
        Container.BindInstance(meshCutSettings);
        Container.BindInstance(movementSettings);
    }
}