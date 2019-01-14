namespace DnD.Characters.Data
{
    public class Repository<T> where T : class
    {
        protected DnDContext _context;

        public Repository(DnDContext context)
        {
            _context = context;
        }
    }
}
