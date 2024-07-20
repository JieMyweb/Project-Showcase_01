using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using pr_model;
using Microsoft.EntityFrameworkCore;
using pr_model.Models;

namespace pr_service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly PGDB_01Context _context;
        public UserService(IMapper mapper, PGDB_01Context context)
        {
            _mapper = mapper;
            _context = context;
        }
        public UserRes GetUsers(UserReq req)
        {
            Users user = _context.Set<Users>().FirstOrDefault(x => x.UserName == req.UserName && x.Password == req.Password);
            if (user != null)
            {
                return _mapper.Map<UserRes>(user);
            }
            return new UserRes();
        }
        public UserRes RegisterUser(RegisterReq req, ref string msg)
        {
            Users user = _context.Set<Users>().FirstOrDefault(x => x.UserName == req.UserName);

            if (user != null)
            {
                msg = "帳號已存在! ";
                return _mapper.Map<UserRes>(user);
            }
            else
            {
                try
                {
                    Users users = _mapper.Map<Users>(req);
                    users.Id = Guid.NewGuid().ToString();
                    users.CreateTime = DateTime.Now;
                    users.UserType = (int)EnumUserType.普通用戶;

                    _context.Users.Add(users);
                    int res = _context.SaveChanges(); // 保存變更並返回受影響的行數

                    if (res > 0)
                    {
                        user = _context.Users.FirstOrDefault(p => p.UserName == req.UserName && p.Password == req.Password);
                        return _mapper.Map<UserRes>(user);
                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return new UserRes();
        }
    }
}