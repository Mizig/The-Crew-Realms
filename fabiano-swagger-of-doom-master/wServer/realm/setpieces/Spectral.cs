namespace wServer.realm.setpieces
{
    internal class Spectral : ISetPiece
    {
        public int Size
        {
            get { return 5; }
        }

        public void RenderSetPiece(World world, IntPoint pos)
        {
            Entity spectral = Entity.Resolve(world.Manager, "Spectral Sentry");
            spectral.Move(pos.X + 2.5f, pos.Y + 2.5f);
            world.EnterWorld(spectral);
        }
    }
}