using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApnaDukaan_v1.BLL.Exceptions
{
    public class ExceptionHelper
    {
        public static bool IsForeignKeyConstraintViolation(DbUpdateException exception)
        {
            return exception.InnerException is SqlException sqlEx && sqlEx.Number == 547; // ForeignKey constraint errors
        }
    }
}
