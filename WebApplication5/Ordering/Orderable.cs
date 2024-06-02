using WebApplication5.Enums;
using WebApplication5.Interfaces;

namespace WebApplication5.Ordering
{
    public class Orderable : IOrderable
    {
        public string Property { get; init; } = "id";

        public Direction Direction { get; init; } = Direction.Asc;
    }
}
