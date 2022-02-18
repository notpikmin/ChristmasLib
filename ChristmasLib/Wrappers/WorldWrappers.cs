using VRC.Core;

namespace ChristmasLib.Wrappers
{
    public static class WorldWrappers
    {
        public static string GetRoomId() { return APIUser.CurrentUser.location; }

    }
}
