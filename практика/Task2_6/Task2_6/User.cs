using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task2_6
{
    enum State
    {
        signin,
        signout
    }

    [Serializable]
    class User: IComparable
    {
        private string email;
        private int password;
        private State status;

        public string Email
        {
            get => email;
            set => email = value;
        }

        public int Password
        {
            get => password;
            set => password = value;
        }

        public State Status
        {
            get => status;
            set => status = value;
        }

        public User() { }
        public User(string mail, int password, State st)
        {
            Email = mail;
            Password = password;
            Status = st;
        }

        public int CompareTo(object obj)
        {
            if (obj is User)
            {
                User us = (User)obj;
                if (Password > us.Password) return 1;
                else if (Password < us.Password) return -1;
                else  return 0;
            }
            else throw new Exception("Данные типы не подлежат сравнению...");
        }

        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User us = (User)obj;
                if (us.Email == email)
                    return true;
                else return false;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return (email.GetHashCode() + base.GetHashCode())/2;
        }

        public override string ToString()
        {
            return $"User(email:{email}, password:*********, status:{status})";
        }


    }
}
