using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public enum GameState
    {
        Intro,
        Start,
        CreateCharacter,
        Load,
        Main,
        Status,
        Shop,
        Dungeon,
        Clear,
        GameOver,

        Retry,
        Pop,
        Exit
    }
}
