using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    //创建 上下文对象 ApplicationDbContext,继承于DbContext
    //DbContext,EntityFramework （简称 EF）中的一个类，可以理解为一个数据库对象的实例。
    //在 EF 中，无需手动的拼接 SQL 语句对数据库进行增删改查，而是通过 DbContext 来进行相应操作。
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<ClassEntiy> ClassEntitys { get; set; }
    }
}
