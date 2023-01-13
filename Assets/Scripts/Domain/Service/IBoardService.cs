public interface IBoardService
{
    public bool CanPut(Mino mino);
    public bool IsOnTrap(Mino mino);
    public void PetMino(Mino mino);

}