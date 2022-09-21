﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Models
{
    public class PlatformRepo: IPlatformRepo
    {
        private readonly AppDbContext _context;
        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }


        public void CreatePlatform(Platform platform)
        {
            if(platform != null)
            {
                _context.Platforms.Add(platform);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.Find(id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}