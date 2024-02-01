using ApnaDukaan_v1.DAL.Entities;

namespace ApnaDukaan_v1.DAL
{
    public class SeedingInitalData
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = 1,
                    RoleName = "Customer"
                },
                new Role
                {
                    Id = 2,
                    RoleName = "Admin"
                },
                new Role
                {
                    Id = 3,
                    RoleName = "GM"
                },
            };
        }

        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id= 1,
                    Name = "Electronics"
                },
                new Category
                {
                    Id= 2,
                    Name = "Clothes"
                },
                new Category
                {
                    Id= 3,
                    Name = "Cosmetics"
                },
                new Category
                {
                    Id= 4,
                    Name = "Furniture"
                },
            };
        }
    }
}
