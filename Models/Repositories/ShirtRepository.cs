using WebAPIDemoOne.Controllers;

namespace WebAPIDemoOne.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
            new Shirt {ShirtId = 2, Brand = "Your Brand", Color = "Red", Gender = "Men", Price = 20, Size = 12},
            new Shirt {ShirtId = 3, Brand = "The best", Color = "Yellow", Gender = "Women", Price = 60, Size = 8}
        };

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}
