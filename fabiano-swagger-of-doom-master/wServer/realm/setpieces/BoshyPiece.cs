namespace wServer.realm.setpieces
{
    internal class BoshyPiece : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity boshy = Entity.Resolve(world.Manager, "Boshy");
            boshy.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(boshy);
        }
    }
}