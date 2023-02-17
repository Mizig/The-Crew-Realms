namespace wServer.realm.setpieces
{
    internal class Cow : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity cow = Entity.Resolve(world.Manager, "Chubby Cow");
            cow.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(cow);
        }
    }
}