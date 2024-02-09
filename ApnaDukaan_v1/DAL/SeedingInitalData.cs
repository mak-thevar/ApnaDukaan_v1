using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Entities.Enums;
using Microsoft.AspNetCore.Identity;

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

        public static User GetAdminUser()
        {
            var password = new PasswordHasher<object>().HashPassword(null, "pwd@1234");
            return new User
            {
                Id = 1,
                FirstName = "Mak",
                LastName = "Thevar",
                Email = "mak.thevar@outlook.com",
                RoleId = 2,
                Username = "mkthevar",
                PhoneNo = "9888888888",
                PasswordHash = password,
            };
        }

        public static User GetCustomer()
        {
            var password = new PasswordHasher<object>().HashPassword(null, "pwd@1234");
            return new User
            {
                Id = 2,
                FirstName = "Punit",
                LastName = "Gupta",
                Email = "punit@gmail.com",
                RoleId = 1,
                Username = "punit",
                PhoneNo = "9888888881",
                PasswordHash = password,
                Dob = DateTime.Now.Date.AddYears(-20),
                Gender = (int)GenderEnum.Male,
            };

        }

        public static Address GetAddress()
        {


            return new Address
            {
                Id = 1,
                City = "Mumbai",
                Landmark = "something",
                Pincode = "400701",
                State = "Maharashtra",
                StreetAddress = "Some street",
                UserId =2
            };

        }


    }
}
