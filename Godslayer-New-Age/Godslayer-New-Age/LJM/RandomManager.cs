
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class RandomManager
{
    //    랜덤값을 사용하는 값
    public static Random Instance { get; } = new Random();
}