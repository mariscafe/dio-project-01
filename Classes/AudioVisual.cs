namespace videos.catalog
{
    public abstract class AudioVisual
    {
        public int id { get; protected set; }
        protected string titulo { get; set; }
        protected string sinopse { get; set; }
        protected Genero genero { get; set; }
        protected bool excluido { get; set; }
    }
}