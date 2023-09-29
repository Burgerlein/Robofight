using Robofight;
using Robofight.GameTypes;

// Setup
IGame game = new DefaultGame();
game.RoundMode = new OneVsOne();
game.GameLoop();