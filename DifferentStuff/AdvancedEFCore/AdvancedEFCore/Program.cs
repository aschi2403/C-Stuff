using AdvancedEFCore;
using System;
using System.Threading.Tasks;

namespace AdvancedEfCore
{
    static partial class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new BookDataContext();
            await CleanDatabaseAsync(context);
            await FillGenreAsync(context);
            await FillBooksAsync(context);
        }
    }
}
