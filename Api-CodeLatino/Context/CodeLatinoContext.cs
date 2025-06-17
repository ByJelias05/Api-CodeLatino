using Microsoft.EntityFrameworkCore;

namespace Api_CodeLatino.Context
{
    public class CodeLatinoContext:DbContext
    {
        public CodeLatinoContext(DbContextOptions<CodeLatinoContext> options) : base(options) { }

        //DbSets
    }
}
