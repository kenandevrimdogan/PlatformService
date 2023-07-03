using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform platform)
    {
        if(platform is null)
        {
            throw new ArgumentNullException(nameof(platform));
        }

        _context.Add<Platform>(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms() => _context.Platforms.ToList();

    public Platform GetPlatformById(int id) => _context.Platforms.SingleOrDefault(platform => platform.Id == id);

    public bool SaveChanges() => (_context.SaveChanges() >= default(int));
}
