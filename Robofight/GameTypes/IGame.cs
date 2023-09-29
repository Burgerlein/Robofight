using Robofight.GameTypes;

namespace Robofight;

public interface IGame
{
    public int RoundNumber { get; }

    public IRoundMode RoundMode { get; set; }
    public void GameLoop();
}