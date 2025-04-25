using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IScene
{
    GameState SceneType { get; }
    GameState Run(int phase);
}