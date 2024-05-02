using System;

public class RandomBoolGenerator
{
    private static Random random = new Random();

    public static bool GetRandomBool()
    {
        return random.Next(2) == 0;
    }
    public static bool GetRandomBoollow()//1/3の確率でtrue
    {
        return random.Next(0,3) == 0;
    }
}