using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!VerifyName(firstName, lastName)) return false;

            if (!VerifyEmail(email)) return false;

            var age = CalcAge(dateOfBirth);

            if (!VerifyAge(age)) return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                CalcImportantLimit(user);
            }
            else
            {
                CalcDefaultLimit(user);
            }

            if (!VeriifyCreditLimit(user)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }
        
        private bool VeriifyCreditLimit(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            return true;
        }

        private void CalcDefaultLimit(User user)
        {
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }

        private void CalcImportantLimit(User user)
        {
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
        }

        private bool VerifyAge(int age)
        {
            if (age < 21)
            {
                return false;
            }

            return true;
        }

        private int CalcAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private bool VerifyEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }

        private bool VerifyName(string firstName, string lastName)
        {
            return !(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName));
        }
    }
}
