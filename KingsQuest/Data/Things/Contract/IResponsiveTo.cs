namespace Data.Things.Contract
{
    public interface IResponsiveTo<TThing> where TThing : Thing
    {
        bool RespondTo(TThing thing, Player actor);
    }
}