using Module.Entities;

namespace Module.Helpers
{
    public class Builder
    {
        MyDbContext _context;
        public Builder(MyDbContext context)
        {
            _context = context;
        }
    }
}