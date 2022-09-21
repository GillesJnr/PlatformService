using System;
using System.Collections;
using System.Collections.Generic;

namespace PlatformService.Models
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform platform);

    }
}
