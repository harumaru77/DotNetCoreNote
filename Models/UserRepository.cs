using System.Collections.Generic;
using System.Linq;

namespace DotNetNote.Models
{
    public class UserRepositoryInMemory : IUserRepository
    {
        private List<UserViewModel> _userList;

        public UserRepositoryInMemory()
        {
            _userList = new List<UserViewModel>();
        }

        // 회원 가입
        void IUserRepository.AddUser(string userId, string password)
        {
            _userList.Add(new UserViewModel() {
                Id = _userList.Count + 1,
                UserId = userId,
                Password = password
            });        
        }

        // 특정 회원 정보 검색
        UserViewModel IUserRepository.GetUserByUserId(string userId)
        {
            UserViewModel r = new UserViewModel();
            
            r = _userList.Find(userModel => userModel.UserId == userId);

            return r;
        }

        int IUserRepository.GetUserCount()
        {
            return _userList.Count;
        }

        bool IUserRepository.IsCorrectUser(string userId, string password)
        {
            if(_userList.Find(userModel => userModel.UserId == userId && userModel.Password == password) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 회원정보 수정 
        void IUserRepository.ModifyUser(int uid, string userId, string password)
        {
            UserViewModel r = new UserViewModel();

            r = _userList.Find(userModel => userModel.Id == uid);

            if(r != null)
            {
                _userList.Remove(r);

                r.UserId = userId;
                r.Password = password;

                _userList.Add(r);
            }
        }        
    }
}