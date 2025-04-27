public interface IScene
{
    GameState SceneType { get; }
    GameState Run(int phase);
}