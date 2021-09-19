using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRC.Core;

namespace ChristmasLib.Wrappers
{
    public static class WorldWrappers
    {
        public static string GetRoomId() { return APIUser.CurrentUser.location; }

    }
}
