using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class TeacherProxyFactory
    {
        Hashtable proxies = new Hashtable();
        ApplicationDbContext _context;
        public TeacherProxyFactory(ApplicationDbContext context)
        {
            _context = context;
            foreach (var pr in context.TeacherProxies)
                proxies.Add(pr.TeacherId, pr);
        }

        public TeacherProxy Get(int teacherId)
        {
            var proxy = proxies[teacherId] as TeacherProxy;
            if (proxy == null)
            {
                var teacher = _context.Teachers.SingleOrDefault(t => t.Id == teacherId);
                proxy = new TeacherProxy(teacher);
                _context.Add(proxy);
            }
            return proxy;
        }
    }
}
