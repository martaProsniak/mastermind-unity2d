public class Guess 
{
    public PegColor[] Code {get; private set;}
    public int BlackPegs {get; private set;}
    public int WhitePegs {get; private set;}

    public Guess(PegColor[] code, int blackPegs, int whitePegs)
    {
        Code = code;
        BlackPegs = blackPegs;
        WhitePegs = whitePegs;
    }
}