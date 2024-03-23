//using Infrastructure.Contexts;
//using Infrastructure.Entities;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;
//using System.Linq.Expressions;

//namespace Infrastructure.Repositories;

//public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context)
//{
//    private readonly DataContext _context = context;

//    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
//    {
//        try
//        {
//            var entities = await _context.Users
//                .Include(i => i.Adresses)
//                .ToListAsync();

//            return entities;
//        }
//        catch (Exception ex) { Debug.WriteLine(ex); }
//        return null!;
//    }

//    public override async Task<UserEntity> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
//    {
//        try
//        {
//            var entity = await _context.Set<UserEntity>()
//                .Include(i => i.Adresses)
//                .FirstOrDefaultAsync(predicate);

//            return entity!;
//        }
//        catch (Exception ex) { Debug.WriteLine(ex); }
//        return null!;
//    }
//}
