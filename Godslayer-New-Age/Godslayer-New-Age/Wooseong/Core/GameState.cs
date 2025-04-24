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
        Save,
        Load,
        Main,
        Inventory,
        Shop,
        Dungeon,
        Rest,
        Clear,
        GameOver,

        Retry,
        Pop,
        Exit
    }
}
