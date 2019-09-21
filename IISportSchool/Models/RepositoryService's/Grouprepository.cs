﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IISportSchool.Models
{
    public class GroupRepository : IGroupRepository
    {
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispose)
        {
            if (!disposed)
            {
                if (dispose)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Group> Groups => _context.Groups;

        public void Add(Group group)
        {
            _context.Groups.Add(group);
        }

        public void Delete(Group group)
        {
            _context.Groups.Remove(group);
        }

        public Group Get(int id)
        {
            var group = _context.Groups.Include(gr => gr.Childrens).Include(gr=>gr.Teacher).SingleOrDefault(g => g.Id == id);
            return group;
        }

        public void Update(Group group)
        {
            _context.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
